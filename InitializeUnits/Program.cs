using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializeUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            var variableTypes = new VariableTypesReader().ReadVariableTypes();
            var mongodb = new MongoDb();
            mongodb.MapVariableType();
            mongodb.Save(variableTypes);
        }
    }
}
