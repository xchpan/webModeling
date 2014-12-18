using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebModeling.Cache
{
    public class HttpCachingHandler : DelegatingHandler
    {
        private static ConcurrentDictionary<string, CacheableEntity> _eTagCacheDictionary = new ConcurrentDictionary<string, CacheableEntity>();
        private readonly string[] _varyHeaders;

        public HttpCachingHandler(params string[] varyHeaders)
        {
            _varyHeaders = varyHeaders;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var resourceKey = GetResourceKey(request.RequestUri, _varyHeaders, request);
            CacheableEntity cacheableEntity = null;
            var cacheControlHeader = new CacheControlHeaderValue {
                Private = true,
                MustRevalidate = true,
                MaxAge = TimeSpan.FromSeconds(0)
            };
            
            if (request.Method == HttpMethod.Get) {
                var eTags = request.Headers.IfNoneMatch;
                var modifiedSince = request.Headers.IfModifiedSince;
                var anyEtagsFromTheClientExist = eTags.Any();
                var doWeHaveAnyCacheableEntityForTheRequest = _eTagCacheDictionary.TryGetValue(resourceKey, out cacheableEntity);
                if (anyEtagsFromTheClientExist) {
                    if (doWeHaveAnyCacheableEntityForTheRequest) {
                        if (eTags.Any(x => x.Tag == cacheableEntity.EntityTag.Tag)) {
                            var tempResp = new HttpResponseMessage(HttpStatusCode.NotModified);
                            tempResp.Headers.CacheControl = cacheControlHeader;
                            return tempResp;
                        }
                    }
                }
                else if (modifiedSince.HasValue) {
                    if (doWeHaveAnyCacheableEntityForTheRequest) {
                        if (cacheableEntity.IsValid(modifiedSince.Value)) {
                            var tempResp = new HttpResponseMessage(HttpStatusCode.NotModified);
                            tempResp.Headers.CacheControl = cacheControlHeader;
                            return tempResp;
                        }
                    }
                }
            }

            // After the action method is executed, put the cache from the response object
            HttpResponseMessage response;
            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(
                HttpStatusCode.InternalServerError, ex);
            }
            if (response.IsSuccessStatusCode)
            {
                if (request.Method == HttpMethod.Get &&
                !_eTagCacheDictionary.TryGetValue(
                resourceKey, out cacheableEntity))
                {
                    cacheableEntity = new CacheableEntity(resourceKey);
                    cacheableEntity.EntityTag = GenerateETag();
                    cacheableEntity.LastModified = DateTimeOffset.Now;
                    _eTagCacheDictionary.AddOrUpdate(
                    resourceKey, cacheableEntity, (k, e) => cacheableEntity);
                }
                if (request.Method == HttpMethod.Get)
                {
                    response.Headers.CacheControl = cacheControlHeader;
                    response.Headers.ETag = cacheableEntity.EntityTag;
                    response.Content.Headers.LastModified = cacheableEntity.LastModified;
                    Array.ForEach(_varyHeaders,
                    varyHeader => response.Headers.Vary.Add(varyHeader));
                }
            }
            return response;
        }

        private string GetResourceKey(Uri uri,
            string[] varyHeaders,
            HttpRequestMessage request)
        {
            return GetResourceKey(GetRequestUri(uri), varyHeaders, request);
        }

        private string GetResourceKey(string trimedRequestUri,
            string[] varyHeaders,
            HttpRequestMessage request)
        {
            var requestedVaryHeaderValuePairs = request.Headers.Where(x => varyHeaders.Contains(x.Key))
                .Select(x => string.Format("{0}:{1}", x.Key, string.Join(";", x.Value)));
            return string.Format("{0}:{1}", trimedRequestUri, string.Join("_", requestedVaryHeaderValuePairs))
                .ToLower(CultureInfo.InvariantCulture);
        }

        private EntityTagHeaderValue GenerateETag()
        {
            var eTag = string.Concat(
            "\"", Guid.NewGuid().ToString("N"), "\"");
            return new EntityTagHeaderValue(eTag);
        }

        private string GetRequestUri(Uri requestUri)
        {
            return string.Concat(requestUri.LocalPath.TrimEnd('/'), requestUri.Query)
                .ToLower(CultureInfo.InvariantCulture);
        }
    }
}