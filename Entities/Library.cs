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
    }
}
