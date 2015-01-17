using System;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class TemplateBase
    {
        private Guid id;

        public TemplateBase(Guid id)
        {
            this.id = id;
        }

        public Guid Id {
            get { return id; }
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}