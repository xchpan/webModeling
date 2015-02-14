using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace xpan.plantDesign.Repository
{
    public interface IVariableTypeRepository
    {
        IEnumerable<VariableCategory> VariableCategories { get; }

        VariableType FindVariableType(string typeName);
    }
}
