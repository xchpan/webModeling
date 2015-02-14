using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;

namespace xpan.plantDesign.Repository
{
    public class VariableTypeRepository : IVariableTypeRepository
    {
        private static bool mapped = false;
        private List<VariableCategory> variableCategories;

        public IEnumerable<Domain.SharedLibraries.VariableTemplate.VariableCategory> VariableCategories
        {
            get { return variableCategories.AsEnumerable(); }
        }

        public VariableType FindVariableType(string typeName)
        {
            foreach (var variableCategory in variableCategories)
            {
                var type = variableCategory.VariableTypes.FirstOrDefault(v => v.Name == typeName);
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        public void Initialize()
        {
            variableCategories = new List<VariableCategory>();

            MapEntities();

            var connectionString = "mongodb://192.168.112.129";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();

            var database = server.GetDatabase("variableType");

            var collection = database.GetCollection<VariableCategory>("variableTypes");
            //variableCategories.AddRange(collection.AsQueryable());
            foreach (var variableCategory in collection.AsQueryable())
            {
                variableCategories.Add(variableCategory);
            }
        }

        private void MapEntities()
        {
            if (mapped)
            {
                return;
            }

            BsonClassMap.RegisterClassMap<TemplateBase>(cm =>
            {
                cm.AutoMap();
                //cm.MapCreator(b => new TemplateBase(b.Id));
            });
            BsonClassMap.RegisterClassMap<Unit>(cm =>
            {
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.ConversionConstant);
                cm.MapProperty(c => c.ConversionFactor);
                cm.MapCreator(u => new Unit(u.Name, u.ConversionConstant, u.ConversionFactor));
            });

            BsonClassMap.RegisterClassMap<UnitCollection>(cm =>
            {
                cm.MapProperty(c => c.PrimaryUnitName);
                cm.MapProperty(c => c.AdditionalUnits);
                cm.MapCreator(uc => new UnitCollection(uc.PrimaryUnitName, uc.AdditionalUnits));
            });

            BsonClassMap.RegisterClassMap<VariableType>(cm =>
            {
                cm.MapProperty(c => c.MaxVallue);
                cm.MapProperty(c => c.MinValue);
                cm.MapProperty(c => c.DefaultValue);
                cm.MapProperty(c => c.Units);
                cm.MapCreator(vt => new VariableType(vt.Id));
            });

            BsonClassMap.RegisterClassMap<VariableCategory>(cm =>
            {
                cm.MapProperty(c => c.VariableTypes);
                cm.MapCreator(vc => new VariableCategory(vc.Id, vc.Name, vc.VariableTypes));
            });

            mapped = true;
        }
    }
}
