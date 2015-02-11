using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public interface ILibraryService
    {
        IEnumerable<Library> GetLibraries();

        Library CreateLibrary();

        void DeleteLibrary(Guid id);

        FluidType CreateFluidInLibrary(Guid id);

        PortTemplate CreatePortInLibrary(Guid id);

        ModelTemplate CreateModelInLibrary(Guid id);
    }
}
