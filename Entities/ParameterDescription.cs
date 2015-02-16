using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class ParameterDescription
    {
        public string Name { get; set; }

        public Guid ParameterType { get; set; }

        public Guid? DefaultFluid { get; set; }

        public double? OverridenDefaultValue { get; set; }
        public double? OverridenMin { get; set; }
        public double? OverridenMax { get; set; }

    }
}
