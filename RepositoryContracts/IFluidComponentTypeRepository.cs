using System.Collections.Generic;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;

namespace xpan.plantDesign.Repository
{
    public interface IFluidComponentTypeRepository
    {
        IEnumerable<FluidComponentType> FluidComponentTypes { get; }
    }
}
