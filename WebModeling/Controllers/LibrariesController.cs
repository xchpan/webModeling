using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.WebHost.Controllers
{
    public class LibrariesController : ApiController
    {
        private ILibraryService libraryService = new LibraryService();

        public IEnumerable<Library> GetLibraries()
        {
            return libraryService.GetLibraries();
        }
    }
}
