using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;

namespace InitializeFluidComponents
{
    public class FluidComponentTypesReader
    {
        public List<FluidComponentType> ReadFluidComponentTypes()
        {
            var types = new List<FluidComponentType>();
            var document = XDocument.Load("Compositional.xml");

            foreach (var element in document.XPathSelectElements("Layout/Components/Component"))
            {
                var name = element.XPathSelectElement("LibraryName").Value;
                var description = element.XPathSelectElement("FullName").Value;
                var firstLevelPaths = element.XPathSelectElements("Level1/Level").Select(e => e.Value).ToList();
                var secondLevelPaths = element.XPathSelectElements("Level2/Level").Select(e => e.Value).ToList();
                types.Add(new FluidComponentType()
                {
                    Name = name,
                    Description = description,
                    FirstLevelSearchPaths = firstLevelPaths,
                    SecondLevelSearchPaths = secondLevelPaths
                });
            }

            return types;
        }
    }
}
