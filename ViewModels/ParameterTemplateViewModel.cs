using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class ParameterTemplateViewModel
    {
        public string Name { get; set; }
        public string OverridenDefaultValue { get; set; }
        public double? OverridenMax { get; set; }
        public double? OverridenMin { get; set; }
        public string ParameterTypeName { get; set; }
        public bool RequireUserToProvideInitialValue { get; set; }
    }
}
