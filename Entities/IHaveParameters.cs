using System;
using System.Collections.Generic;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public interface IHaveParameters
    {
        void AddParameter(string name, VariableType parameterType, double? defaultValue);
        void DeleteParameter(string name);
        void RenameParameter(string oldName, string newName);
        void ChangeParameterType(string name, VariableType parameterType, double? defaultValue);
        void ChangeParameterDefaultValue(string name, object defaultValue);
        IEnumerable<ParameterDescription> Parameters { get; }
    }
}