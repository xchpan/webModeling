using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class ParameterDescription
    {
        public string Name { get; set; }

        public VariableType ParameterType { get; set; }

        public bool RequireUserToProvideInitialValue { get; set; }

        public double? OverridenDefaultValue { get; set; }
        public double? OverridenMin { get; set; }
        public double? OverridenMax { get; set; }
        
    }
}
