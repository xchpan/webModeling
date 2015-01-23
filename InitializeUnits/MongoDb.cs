using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace InitializeUnits
{
    public class MongoDb
    {
        public void Save(IEnumerable<VariableCategory> variableCategories)
        {
            var connectionString = "mongodb://192.168.112.129";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();

            var database = server.GetDatabase("variableType");

            var collection = database.GetCollection<VariableCategory>("variableTypes");
            foreach (var variableCategory in variableCategories)
            {
                collection.Save(variableCategory);
            }
        }

        public void MapVariableType()
        {
            BsonClassMap.RegisterClassMap<TemplateBase>(cm =>
            {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Unit>(cm =>
            {
                cm.MapProperty(c => c.ConversionConstant);
                cm.MapProperty(c => c.ConversionFactor);
            });

            BsonClassMap.RegisterClassMap<UnitCollection>(cm =>
            {
                cm.MapProperty(c => c.PrimaryUnitName);
                cm.MapProperty(c => c.AdditionalUnits);
            });

            BsonClassMap.RegisterClassMap<VariableType>(cm =>
            {
                cm.MapProperty(c => c.MaxVallue);
                cm.MapProperty(c => c.MinValue);
                cm.MapProperty(c => c.DefaultValue);
                cm.MapProperty(c => c.Units);
            });

            BsonClassMap.RegisterClassMap<VariableCategory>(cm =>
            {
                cm.MapProperty(c => c.VariableTypes);
            });
        }
    }
}
