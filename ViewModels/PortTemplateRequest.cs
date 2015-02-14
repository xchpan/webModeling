using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class PortTemplateRequest
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] Parameters { get; set; }
        public string Type { get; set; }
        public VariableTemplateViewModel[] Variables { get; set; }
    }
}
