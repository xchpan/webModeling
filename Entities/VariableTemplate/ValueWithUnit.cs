using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class ValueWithUnit
    {
        public ValueWithUnit(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public double Value { get; set; }

        public Unit Unit { get; private set; }
    }
}
