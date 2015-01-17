using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.FluidTemplate
{
    public class FluidComponent : TemplateBase
    {
        public FluidComponent(Guid id) : base(id)
        {
            StartingComposition = 1.0;
        }

        public string FluidComponentType { get; set; }

        public double StartingComposition { get; set; }
    }
}
