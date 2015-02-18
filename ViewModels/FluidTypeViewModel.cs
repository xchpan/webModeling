using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class FluidTypeViewModel : LibraryItemViewModel
    {
        private const string TypeString = "Fluid";

        public override string Type
        {
            get { return TypeString; }
        }

        public string ThermoType { get; set; }

        public double StartingPressureValue { get; set; }

        public double StartingTemprature { get; set; }

        public string SystemMethod { get; set; }

        public string PhaseMethod { get; set; }

        public string LiquidDensityMethod { get; set; }

        public IEnumerable<FluidComponentViewModel> FluidComponents { get; set; }
    }
}
