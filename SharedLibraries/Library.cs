using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class Library
    {
        private readonly Guid id;
        private List<FluidTemplate> fluidTemplates = new List<FluidTemplate>();
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
    }
}
