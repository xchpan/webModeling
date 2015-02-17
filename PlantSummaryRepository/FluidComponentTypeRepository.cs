using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;

namespace xpan.plantDesign.Repository
{
    public class FluidComponentTypeRepository : IFluidComponentTypeRepository
    {
        private static bool mapped = false;
        private List<FluidComponentType> fluidComponentTypes;

        public IEnumerable<FluidComponentType> FluidComponentTypes 
        { get { return fluidComponentTypes.AsEnumerable(); } }

        public void Initialize()
        {
            fluidComponentTypes = new List<FluidComponentType>();

            MapEntities();

            var connectionString = "mongodb://192.168.112.129";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();

            var database = server.GetDatabase("variableType");

            var collection = database.GetCollection<FluidComponentType>("fluidComponentTypes");
            //variableCategories.AddRange(collection.AsQueryable());
            foreach (var componentType in collection.AsQueryable())
            {
                fluidComponentTypes.Add(componentType);
            }
        }

        private void MapEntities()
        {
            if (mapped)
            {
                return;
            }

            BsonClassMap.RegisterClassMap<FluidComponentType>(cm =>
            {
                cm.AutoMap();
                cm.MapIdField(m => m.Name);
                //cm.MapCreator(b => new TemplateBase(b.Id));
            });
            mapped = true;
        }
    }
}
