using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class VariableCategory : TemplateBase
    {
        private List<VariableType> variableTypes;

        public VariableCategory(Guid id, string name) : base(id)
        {
            Name = name;
            variableTypes = new List<VariableType>();
        }

        public void Add(VariableType variableType)
        {
            variableTypes.Add(variableType);
        }

        public IEnumerable<VariableType> VariableTypes
        {
            get { return variableTypes.AsEnumerable(); }
        }
    }
}
