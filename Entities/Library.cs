using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class Library
    {
        private readonly Guid id;
        private List<FluidType> fluidTemplates = new List<FluidType>();
        private List<PortTemplate> portTemplates = new List<PortTemplate>();
        private List<ModelTemplate> modelTemplates = new List<ModelTemplate>();

        public Library() : this(Guid.NewGuid())
        {
        }

        public Library(Guid id)
        {
            this.id = id;
        }
        public Guid Id { get { return id; } }

        public string Name { get; set; }

        public IEnumerable<FluidType> FluidTemplates
        {
            get { return fluidTemplates.AsEnumerable(); }
        }

        public IEnumerable<PortTemplate> PortTemplates
        {
            get { return portTemplates.AsEnumerable(); }
        }

        public IEnumerable<ModelTemplate> ModelTemplates
        {
            get { return modelTemplates.AsEnumerable(); }
        }

        public void Add(FluidType fluid)
        {
            if (fluidTemplates.FirstOrDefault(f => f.Id == fluid.Id || f.Name == fluid.Name) != null)
            {
                throw new ArgumentException("The model id or name already exists.");
            }

            fluidTemplates.Add(fluid);
        }

        public void Add(PortTemplate port)
        {
            if (portTemplates.FirstOrDefault(p => p.Id == port.Id || p.Name == port.Name) != null)
            {
                throw new ArgumentException("The model id or name already exists.");
            }

            portTemplates.Add(port);
        }

        public void Add(ModelTemplate model)
        {
            if (portTemplates.FirstOrDefault(m => m.Id == model.Id || m.Name == model.Name) != null)
            {
                throw new ArgumentException("The model id or name already exists.");
            }

            modelTemplates.Add(model);
        }

        public bool ContainsFluidName(string name)
        {
            return fluidTemplates.FirstOrDefault(f => f.Name == name) != null;
        }

        public bool ContainsPortName(string name)
        {
            return portTemplates.FirstOrDefault(f => f.Name == name) != null;
        }

        public bool ContainsModelName(string name)
        {
            return modelTemplates.FirstOrDefault(f => f.Name == name) != null;
        }

        public void Update(PortTemplate port)
        {
            var existing = portTemplates.First(p => p.Id == port.Id);
            portTemplates.Remove(existing);
            portTemplates.Add(port);
        }
    }
}
