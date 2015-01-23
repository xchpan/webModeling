using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    class UnitException : Exception
    {
        public UnitException(string message) : base(message) {}
    }
}
