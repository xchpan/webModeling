using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public class PortTemplate : LibraryItem, IHaveParameters
    {
        private const string PortType = "Port";

        private readonly List<ParameterDescription> parameters;
        private readonly List<VariableDescription> variables;

        public PortTemplate(Guid id)
            : this(id, Enumerable.Empty<ParameterDescription>(), Enumerable.Empty<VariableDescription>())
        {
        }

        public PortTemplate(Guid id, IEnumerable<ParameterDescription> parameters,
            IEnumerable<VariableDescription> variables) : base(id)
        {
            this.parameters = parameters.ToList();
            this.variables = variables.ToList();
        }

        public void AddParameter(string name, Guid parameterType, object defaultValue)
        {
            if (parameters.FirstOrDefault(p => p.Name == name) != null)
            {
                throw new ArgumentException("The parameter name already exist");
            }

            //parameters.Add(new ParameterDescription() {Name = name, ParameterType = parameterType, DefaultValue = defaultValue});
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
            if (String.Equals(oldName, newName, StringComparison.Ordinal))
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
            //parameter.DefaultValue = defaultValue;
        }

        public void ChangeParameterDefaultValue(string name, object defaultValue)
        {
            var parameter = parameters.FirstOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new ArgumentException("The parameter name doesn't exist.");
            }

           // parameter.DefaultValue = defaultValue;
        }

        public IEnumerable<ParameterDescription> Parameters
        {
            get { return parameters.AsEnumerable(); }
        }

        public VariableDescription AddVariable(string name, Guid variableType)
        {
            if (variables.FirstOrDefault(v => v.Name == name) != null)
            {
                throw new ArgumentException("The variable name already exist");
            }

            var variable = new VariableDescription {Name = name, VariableType = variableType};
            variables.Add(variable);
            return variable;
        }

        public void DeleteVariable(string name)
        {
            var variable = variables.FirstOrDefault(p => p.Name == name);
            if (variable == null)
            {
                throw new ArgumentException("The variable name doesn't exist.");
            }
            variables.Remove(variable);
        }

        public void RenameVariable(string oldName, string newName)
        {
            if (String.Equals(oldName, newName, StringComparison.Ordinal))
            {
                throw new ArgumentException("The old name and new name are same");
            }

            var variable = variables.FirstOrDefault(p => p.Name == oldName);
            if (variable == null)
            {
                throw new ArgumentException("the old variable name doesn't exist", "oldName");
            }

            if (variables.FirstOrDefault(p => p.Name == newName) != null)
            {
                throw new ArgumentException("the new variable name already exist", "newName");
            }

            variable.Name = newName;
        }

        public void ChangeVariableType(string name, Guid variableType)
        {
            var variable = variables.FirstOrDefault(p => p.Name == name);
            if (variable == null)
            {
                throw new ArgumentException("The variable name doesn't exist.");
            }

            variable.VariableType = variableType;
            variable.OverridenDefaultValue = (double?) null;
        }

        public void ChangeVariableDefaultValue(string name, double defaultValue)
        {
            var variable = variables.FirstOrDefault(p => p.Name == name);
            if (variable == null)
            {
                throw new ArgumentException("The variable name doesn't exist.");
            }

            variable.OverridenDefaultValue = defaultValue;
        }

        public IEnumerable<VariableDescription> Variables
        {
            get { return variables.AsEnumerable(); }
        }


        public override string Type
        {
            get { return PortType; }
        }
    }
}
