using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class ModelTemplate : LibraryItem
    {
        private const string ModelType = "Model";

        public ModelTemplate(Guid id) : base(id)
        {
        }

        public override string Type
        {
            get { return ModelType; }
        }
    }
}
