using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class PortTemplateViewModel : LibraryItemViewModel
    {
        private const string PortType = "Port";
        public override string Type {
            get { return PortType; }
        }

        public IEnumerable<ParameterTemplateViewModel> Parameters { get; set; }

        public IEnumerable<VariableTemplateViewModel> Variables { get; set; }

        public Dictionary<string, string> Fluids { get; set; }
    }
}
