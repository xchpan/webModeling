using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class ModelTemplateViewModel : LibraryItemViewModel
    {
        private const string ModelType = "Model";
        public override string Type
        {
            get { return ModelType; }
        }

        public IEnumerable<ParameterTemplateViewModel> Parameters { get; set; }
        public IEnumerable<PortViewModel> Ports { get; set; }
        public IEnumerable<ConditionTemplateViewModel> Conditions { get; set; }
        public IEnumerable<ConditionedVariableTemplateViewModel> Variables { get; set; }
        public IEnumerable<SubmodelTemplateViewModel> Submodels { get; set; }
    }
}
