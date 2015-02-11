using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public abstract class LibraryItem : TemplateBase
    {
        protected LibraryItem(Guid id) : base(id)
        {
        }

        public string Icon { get; set; }
        public abstract string Type { get; }
    }
}
