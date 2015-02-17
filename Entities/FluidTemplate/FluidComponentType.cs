using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.FluidTemplate
{
    public class FluidComponentType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Subcategories { get; set; }
    }
}
