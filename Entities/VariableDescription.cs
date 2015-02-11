using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class VariableDescription
    {
        public string Name { get; set; }

        public Guid VariableType { get; set; }

        public double? OverridenMin { get; set; }

        public double? OverridenMax { get; set; }

        public double? OverridenDefaultValue { get; set; }

        public bool IsFixedValue { get; set; }

        public bool RequireUserToProvideInitialValue { get; set; }
    }
}
