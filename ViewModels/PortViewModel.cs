using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class PortViewModel
    {
        public string Name { get; set; }
        public string Direction { get; set; }
        public string PortTemplateName { get; set; }
        public Guid PortTemplateId { get; set; }
    }
}
