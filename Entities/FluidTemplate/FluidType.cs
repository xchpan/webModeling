using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace xpan.plantDesign.Domain.SharedLibraries.FluidTemplate
{
    public class FluidType : LibraryItem
    {

        private readonly List<FluidComponent> components;

        public FluidType(Guid id) : base(id)
        {
            components = new List<FluidComponent>();
            StartingPressureInkPa = 1000;
            StartingTempratureInK = 273;
        }

        public ThermoTypes ThermoType { get; set; }

        public double StartingPressureInkPa { get; set; }

        public double StartingTempratureInK { get; set; }

        public string SystemMethod { get; set; }

        public PhaseMethods PhaseMethod { get; set; }

        public LiquidDensityMethods LiquidDensityMethod { get; set; }

        public void AddFluidComponent(string name, FluidComponentType componentType, double startingValue)
        {
            if (components.FirstOrDefault(p => p.Name == name) != null)
            {
                throw new ArgumentException("The component name already exist");
            }

            components.Add(new FluidComponent(Guid.NewGuid()) { Name = name, FluidComponentType = componentType, StartingComposition = startingValue });
        }

        public void DeleteComponent(string name)
        {
            var component = components.FirstOrDefault(p => p.Name == name);
            if (component == null)
            {
                throw new ArgumentException("The component name doesn't exist.");
            }
            components.Remove(component);
        }

        public void RenameComponent(string oldName, string newName)
        {
            if (string.Equals(oldName, newName, StringComparison.Ordinal))
            {
                throw new ArgumentException("The old name and new name are same");
            }

            var component = components.FirstOrDefault(p => p.Name == oldName);
            if (component == null)
            {
                throw new ArgumentException("the old component name doesn't exist", "oldName");
            }

            if (components.FirstOrDefault(p => p.Name == newName) != null)
            {
                throw new ArgumentException("the new component name already exist", "newName");
            }

            component.Name = newName;
        }

        public void ChangeComponentType(string name, FluidComponentType componentType)
        {
            var component = components.FirstOrDefault(p => p.Name == name);
            if (component == null)
            {
                throw new ArgumentException("The component name doesn't exist.");
            }

            component.FluidComponentType = componentType;
        }

        public void ChangeComponentStartingValue(string name, double startingValue)
        {
            var component = components.FirstOrDefault(p => p.Name == name);
            if (component == null)
            {
                throw new ArgumentException("The component name doesn't exist.");
            }

            component.StartingComposition = startingValue;
        }

        public IEnumerable<FluidComponent> Components {
            get { return components.AsEnumerable(); }
        }
    }
}
