using System.Collections.Generic;
using System.Web.Http;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.WebApi.Controllers
{
    public class LibrariesController : ApiController
    {
        private readonly ILibraryService libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        public IEnumerable<Library> GetLibraries()
        {
            return libraryService.GetLibraries();
        }

        [HttpPost]
        public Library CreateLibrary()
        {
            return libraryService.CreateLibrary();
        }
    }
}
