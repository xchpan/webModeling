using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.ViewModels
{
    public class FluidComponentTypesViewModel
    {
        public class FluidComponentSubcategory
        {
            private readonly string name;
            public string Name { get { return name; }  }

            private List<string> components;
            public IEnumerable<string> FluidComponents { get { return components.AsEnumerable(); } }

            public FluidComponentSubcategory(string name)
            {
                this.name = name;
                components = new List<string>();
            }

            internal void AddFluidComponentType(string name)
            {
                components.Add(name);
            }
        }
        public class FluidComponentCategory
        {
            private readonly string name;
            public string Name { get { return name; }  }

            private List<FluidComponentSubcategory> subcategories;
            public IEnumerable<FluidComponentSubcategory> Subcategories {
                get { return subcategories.AsEnumerable(); }
            }

            public FluidComponentCategory(string name)
            {
                this.name = name;
                subcategories = new List<FluidComponentSubcategory>();
            }

            internal FluidComponentSubcategory FindOrCreateSubcategory(string subcategoryName)
            {
                var subcategory = subcategories.FirstOrDefault(c => c.Name == subcategoryName);
                if (subcategory == null)
                {
                    subcategory = new FluidComponentSubcategory(subcategoryName);
                    subcategories.Add(subcategory);
                }

                return subcategory;
            }
        }

        private List<FluidComponentCategory> categories = new List<FluidComponentCategory>();

        public IEnumerable<FluidComponentCategory> FluidComponentCategories
        {
            get { return categories.AsEnumerable(); }
        }

        public void AddFluidComponentType(IEnumerable<string> categoryNames, IEnumerable<string> subcategoryNames,
            string name)
        {
            foreach (var categoryName in categoryNames)
            {
                var category = categories.FirstOrDefault(c => c.Name == categoryName);
                if (category == null)
                {
                    category = new FluidComponentCategory(categoryName);
                    categories.Add(category);
                }

                foreach (var subcategoryName in subcategoryNames)
                {
                    var subcategory = category.FindOrCreateSubcategory(subcategoryName);
                    subcategory.AddFluidComponentType(name);
                }
            }
        }
    }
}
