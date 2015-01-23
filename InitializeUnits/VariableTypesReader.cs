using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace InitializeUnits
{
    public class VariableTypesReader
    {
        public List<VariableCategory> ReadVariableTypes()
        {
            var variableTypes = new List<VariableCategory>();

            XDocument document = XDocument.Load("VariableTypes.xml");

            foreach (var variableTypeElement in document.Root.XPathSelectElements("VariableType"))
            {
                var categoryName = variableTypeElement.XPathSelectElement("Category").Value;
                var category = variableTypes.FirstOrDefault(c => c.Name == categoryName);
                if (category == null)
                {
                    category = new VariableCategory(Guid.NewGuid(), categoryName);
                    variableTypes.Add(category);
                }

                var variableType = new VariableType(Guid.NewGuid())
                {
                    Name = variableTypeElement.XPathSelectElement("Type").Value,
                    Description = variableTypeElement.XPathSelectElement("Description").Value
                };

                double max = double.MaxValue;
                double.TryParse(variableTypeElement.XPathSelectElement("Max").Value, out max);
                double min = double.MinValue;
                double.TryParse(variableTypeElement.XPathSelectElement("Min").Value, out min);
                if (max == 0 && min == 0)
                {
                    max = double.MaxValue;
                    min = double.MinValue;
                }
                double defaultValue = 0;
                double.TryParse(variableTypeElement.XPathSelectElement("Default").Value, out defaultValue);
                variableType.SetMinMaxDefaultValue(min:min, max:max, defaultValue:defaultValue);

                var internalUnitName = variableTypeElement.XPathSelectElement("InternalUnit").Value;
                variableType.Units = new UnitCollection(Guid.NewGuid(), internalUnitName,
                    new List<Unit>());

                foreach (var conversionUnitElement in variableTypeElement.XPathSelectElements("ConversionFactors/ConversionUnit"))
                {
                    if (conversionUnitElement.Attribute("Name").Value == internalUnitName)
                    {
                        continue;
                    }

                    variableType.Units.AddUnit( name:conversionUnitElement.Attribute("Name").Value,
                        conversionConstant: double.Parse(conversionUnitElement.Attribute("AdditionConstant").Value),
                        conversionFactor: double.Parse(conversionUnitElement.Attribute("MultiplicationConstant").Value));
                }

                category.Add(variableType);
            }

            return variableTypes;
        }
    }
}
