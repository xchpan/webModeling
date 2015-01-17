using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class Unit
    {
        private readonly string name;
        private readonly double conversionConstant;
        private readonly double conversionFactor;

        public Unit(string name, double conversionConstant, double conversionFactor)
        {
            this.name = name;
            this.conversionConstant = conversionConstant;
            this.conversionFactor = conversionFactor;
        }

        public string Name { get { return name; } }

        public double ConversionConstant { get { return conversionConstant; } }

        public double ConversionFactor { get { return conversionFactor; } }
    }
}
