using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class ConditionTemplate : TemplateBase
    {
        public ConditionTemplate(Guid id) : base(id)
        { }

        private string formula;

        public string Formula { get { return formula; } }

        public void SetFormula(string formula)
        {
            this.formula = formula;
        }
    }
}
