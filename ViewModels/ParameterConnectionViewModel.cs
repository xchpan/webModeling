using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class ParameterConnectionViewModel
    {
        public Guid Id { get; set; }
        public string SourcePath { get; set; }
        public string SinkPath { get; set; }
    }
}
