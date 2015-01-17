using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class PortTemplate : IHaveParameters
    {
        private readonly Guid id;
        private readonly ICollection<ParameterDescription> parameters = new List<ParameterDescription>();
        
        public PortTemplate(Guid id)
        {
            this.id = id;
        }

        public Guid Id {
            get { return id; }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public void AddParameter(string name, Guid parameterType, object defaultValue)
        {
            if (parameters.FirstOrDefault(p => p.Name == name) != null)
            {
                throw new ArgumentException("The parameter name already exist");
            }

            parameters.Add(new ParameterDescription() {Name = name, ParameterType = parameterType, DefaultValue = defaultValue});
        }

        public void DeleteParameter(string name)
        {
            var parameter = parameters.FirstOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new ArgumentException("The parameter name doesn't exist.");
            }
            parameters.Remove(parameter);
        }

        public void RenameParameter(string oldName, string newName)
        {
            if (string.Equals(oldName, newName, StringComparison.Ordinal))
            {
                throw new ArgumentException("The old name and new name are same");
            }

            var parameter = parameters.FirstOrDefault(p => p.Name == oldName);
            if (parameter == null)
            {
                throw new ArgumentException("the old parameter name doesn't exist", "oldName");
            }

            if (parameters.FirstOrDefault(p => p.Name == newName) != null)
            {
                throw new ArgumentException("the new parameter name already exist", "newName");
            }

            parameter.Name = newName;
        }

        public void ChangeParameterType(string name, Guid parameterType, object defaultValue)
        {
            var parameter = parameters.FirstOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new ArgumentException("The parameter name doesn't exist.");
            }

            parameter.ParameterType = parameterType;
            parameter.DefaultValue = defaultValue;
        }

        public void ChangeParameterDefaultValue(string name, object defaultValue)
        {
            var parameter = parameters.FirstOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new ArgumentException("The parameter name doesn't exist.");
            }

            parameter.DefaultValue = defaultValue;
        }

        public IEnumerable<ParameterDescription> Parameters
        {
            get { return parameters.AsEnumerable(); }
        }
    }
}
