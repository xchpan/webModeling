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
    }
}
