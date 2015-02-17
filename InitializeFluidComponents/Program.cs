using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializeFluidComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = new FluidComponentTypesReader().ReadFluidComponentTypes();
            var db = new MongoDb();
            db.MapFluidComponentType();
            db.Save(types);
            Console.ReadKey();
        }
    }
}
