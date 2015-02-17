using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;

namespace InitializeFluidComponents
{
    public class MongoDb
    {
        public void Save(IEnumerable<FluidComponentType> fluidComponentTypes)
        {
            var connectionString = "mongodb://192.168.112.129";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();

            var database = server.GetDatabase("variableType");

            var collection = database.GetCollection<FluidComponentType>("fluidComponentTypes");
            foreach (var fluidComponentType in fluidComponentTypes)
            {
                collection.Save(fluidComponentType);
            }
        }

        public void MapFluidComponentType()
        {
            BsonClassMap.RegisterClassMap<FluidComponentType>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(m => m.Name);
                //cm.MapProperty(m => m.Description);
                //cm.MapProperty(m => m.)
            });
        }
    }
}
