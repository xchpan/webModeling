using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class ModelTemplate : LibraryItem
    {
        private readonly List<ParameterDescription> parameters;

        public ModelTemplate(Guid id)
            : this(id, Enumerable.Empty<ParameterDescription>())
        {
        }

        public ModelTemplate(Guid id, IEnumerable<ParameterDescription> parameters) : base(id)
        {
            this.parameters = parameters.ToList();
        }

        public IEnumerable<ParameterDescription> Parameters
        {
            get { return parameters.AsEnumerable(); }
        }
    }
}
