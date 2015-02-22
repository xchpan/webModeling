using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class VariableSharingViewModel
    {
        public Guid Id { get; set; }
        public string FirstVariablePath { get; set; }
        public string SecondVariablePath { get; set; }
    }
}
