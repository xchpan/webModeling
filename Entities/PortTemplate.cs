﻿using System;
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

        private readonly ICollection<ParameterDescription> parameters = new List<ParameterDescription>();
        
        public PortTemplate(Guid id) : base(id)
        {
        }

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

        public override string Type
        {
            get { return PortType; }
        }
    }
}
