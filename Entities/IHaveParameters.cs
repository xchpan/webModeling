using System;
using System.Collections.Generic;

namespace xpan.plantDesign.Domain.SharedLibraries
{
    public interface IHaveParameters
    {
        void AddParameter(string name, Guid parameterType, object defaultValue);
        void DeleteParameter(string name);
        void RenameParameter(string oldName, string newName);
        void ChangeParameterType(string name, Guid parameterType, object defaultValue);
        void ChangeParameterDefaultValue(string name, object defaultValue);
        IEnumerable<ParameterDescription> Parameters { get; }
    }
}