using System;
using System.Collections.Generic;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class UnitSystem : TemplateBase
    {
        private Dictionary<string, Dictionary<UnitCollection, Unit>> units; // category  -> unit collection -> display unit

        public UnitSystem(Guid id, string name) : base(id)
        {
            this.Name = name;
            units = new Dictionary<string, Dictionary<UnitCollection, Unit>>();
        }

        public void AddUnit(string category, UnitCollection unitCollection, Unit displayUnit)
        {
            if (!unitCollection.Contains(displayUnit))
            {
                throw new ArgumentException("The display unit doesn't belong to this unitCollection.");
            }

            if (units.ContainsKey(category) && units[category].ContainsKey(unitCollection))
            {
                throw new UnitException("The unitCollection already exists.");
            }

            if (!units.ContainsKey(category))
            {
                units.Add(category, new Dictionary<UnitCollection, Unit>());
            }
            this.units[category].Add(unitCollection, displayUnit);
        }
    }
}