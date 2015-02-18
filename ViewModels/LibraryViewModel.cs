using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class LibraryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<LibraryItemViewModel> Items { get; set; }
    }
}
