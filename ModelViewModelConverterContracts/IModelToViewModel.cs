using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;
using xpan.plantDesign.ViewModels;

namespace ModelViewModelConverterContracts
{
    public interface IModelToViewModel
    {
        FluidTypeViewModel ToViewModel(FluidType fluid);
        PortTemplateViewModel ToViewModel(PortTemplate port);
        ModelTemplateViewModel ToViewModel(ModelTemplate model);
    }
}
