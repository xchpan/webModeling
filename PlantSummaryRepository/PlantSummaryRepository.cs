using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cassandra;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.Repository
{
    public class PlantSummaryRepository : IPlantSummaryRepository
    {
        private readonly Cluster cluster;
        private readonly ISession session;

        private readonly Dictionary<Guid, PlantSummary> plants = new Dictionary<Guid, PlantSummary>();

        public PlantSummaryRepository()
        {
            var ip = "192.168.112.129";
            cluster = Cluster.Builder().AddContactPoint(ip).Build();
            session = cluster.Connect("plant_building");
        }

        public System.Collections.Generic.IEnumerable<ViewModels.PlantSummary> GetAllPlants()
        {
            if (plants.Count == 0)
            {
                var rowset = session.Execute("SELECT id, name, description, creator, create_dateTime FROM plant_summary");

                foreach (var row in rowset)
                {
                    var id = row.GetValue<Guid>("id");
                    plants.Add(id, new PlantSummary()
                    {
                        Id = id,
                        Name = row.GetValue<string>("name"),
                        Description = row.GetValue<string>("description"),
                        Creator = row.GetValue<string>("creator"),
                        CreateDatetime = row.GetValue<DateTime>("create_datetime")
                    });
                }
            }

            return plants.Values;
        }

        public ViewModels.PlantSummary GetPlant(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(ViewModels.PlantSummary plantSummary)
        {
            const string format = "insert into plant_summary (id, name, description, creator, create_datetime) values ({0}, '{1}', '{2}', '{3}', '{4}')";
            var statement = string.Format(format, plantSummary.Id, plantSummary.Name, plantSummary.Description,
                plantSummary.Creator, plantSummary.CreateDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
            session.Execute(statement);
            plants.Add(plantSummary.Id, plantSummary);
        }

        public void Update(System.Guid id, ViewModels.PlantSummary plantSummary)
        {
            const string format = "update plant_summary set name='{0}', description='{1}' where id={2}";
            var statement = string.Format(format, plantSummary.Name, plantSummary.Description, plantSummary.Id);
            session.Execute(statement);
            plants[id] = plantSummary;
        }

        public void Delete(System.Guid id)
        {
            const string format = "delete from plant_summary where id = {0}";
            var statement = string.Format(format, id);
            session.Execute(statement);
            plants.Remove(id);
        }
    }
}
