using System;
using System.Collections.Generic;
using System.Web.Http;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;
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

        public void DeleteLibrary(Guid id)
        {
            libraryService.DeleteLibrary(id);
        }

        [Route("api/libraries/{id}/fluid")]
        [HttpPost]
        public FluidType CreateFluid(Guid id)
        {
            return libraryService.CreateFluidInLibrary(id);
        }

        [Route("api/libraries/{id}/port")]
        [HttpPost]
        public PortTemplate CreatePort(Guid id)
        {
            return libraryService.CreatePortInLibrary(id);
        }

        [Route("api/libraries/{id}/Model")]
        [HttpPost]
        public ModelTemplate CreateModel(Guid id)
        {
            return libraryService.CreateModelInLibrary(id);
        }
    }
}
