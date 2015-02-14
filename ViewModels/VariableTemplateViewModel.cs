using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class VariableTemplateViewModel
    {
        public bool IsFixedValue { get; set; }
        public string Name { get; set; }
        public double? OverridenDefaultValue { get; set; }
        public double? OverridenMax { get; set; }
        public double? OverridenMin { get; set; }
        public bool RequireUserToProvideInitialValue { get; set; }
        public string VariableTypeName { get; set; }
    }
}
