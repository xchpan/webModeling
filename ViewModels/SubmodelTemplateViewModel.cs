using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class SubmodelTemplateViewModel
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public string ModelTypeName { get; set; }
        public Guid ModelTypeId { get; set; }
    }
}
