using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class UnitCollection
    {
        private readonly Unit primaryUnit;

        private readonly List<Unit> additionalUnits;

        public UnitCollection(string primaryUnitName, IEnumerable<Unit> additionalUnits)
        {
            this.additionalUnits = additionalUnits.ToList();
            primaryUnit = new Unit(primaryUnitName, 0, 1);
        }

        public string PrimaryUnitName
        {
            get { return primaryUnit.Name; }
        }

        public IEnumerable<string> AdditionalUnitNames
        {
            get { return additionalUnits.Select(u => u.Name); }
        }

        public IEnumerable<Unit> AdditionalUnits
        {
            get { return additionalUnits.AsEnumerable(); }
        }

        public void AddUnit(string name, double conversionConstant, double conversionFactor)
        {
            if (name == primaryUnit.Name || additionalUnits.FirstOrDefault(u => u.Name == name) != null)
            {
                throw new ArgumentException("unit name already exist.");
            }

            additionalUnits.Add(new Unit(name, conversionConstant, conversionFactor));
        }

        public bool Contains(Unit unit)
        {
            return primaryUnit == unit || additionalUnits.Contains(unit);
        }

        public double ToDisplayUnit(double valueInPrimaryUnit, Unit displayUnit)
        {
            if (!Contains(displayUnit))
            {
                throw new ArgumentException("The display unit doesn't belong to this unit collection");
            }

            return valueInPrimaryUnit*displayUnit.ConversionFactor + displayUnit.ConversionConstant;
        }
    }
}
