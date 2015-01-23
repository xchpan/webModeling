using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class UnitCollection : TemplateBase
    {
        private readonly Unit primaryUnit;

        private readonly List<Unit> additionalUnits;

        public UnitCollection(Guid id, string primaryUnitName, List<Unit> additionalUnits) : base(id)
        {
            this.additionalUnits = additionalUnits.ToList();
            primaryUnit = new Unit(primaryUnitName, 0, 1);
        }

        public IEnumerable<Unit> Units
        {
            get
            {
                yield return primaryUnit;
                foreach (var unit in additionalUnits)
                {
                    yield return unit;
                }
            }
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
