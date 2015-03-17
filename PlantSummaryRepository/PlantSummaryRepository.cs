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
        private readonly PreparedStatement insertPlantSummaryStatement;
        private readonly PreparedStatement updatePlantSummaryStatement;
        private readonly PreparedStatement deletePlantSummaryStatement;

        private readonly Dictionary<Guid, PlantSummary> plants = new Dictionary<Guid, PlantSummary>();

        public PlantSummaryRepository(string ip)
        {
            //var ip = "192.168.112.129";
            cluster = Cluster.Builder().AddContactPoint(ip).Build();
            session = cluster.Connect("plant_building");

            insertPlantSummaryStatement = session.Prepare(
                "INSERT INTO plant_summary (id, name, description, creator, create_datetime) VALUES (?, ?, ?, ?, ?);");
            updatePlantSummaryStatement = session.Prepare("UPDATE plant_summary SET name=?, description=? WHERE id=?;");
            deletePlantSummaryStatement = session.Prepare("DELETE FROM plant_summary WHERE id = ?");
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
            var statement = insertPlantSummaryStatement.Bind(plantSummary.Id, plantSummary.Name, plantSummary.Description,
                plantSummary.Creator, plantSummary.CreateDatetime);
            session.Execute(statement);
            plants.Add(plantSummary.Id, plantSummary);
        }

        public void Update(System.Guid id, ViewModels.PlantSummary plantSummary)
        {
            var statement = updatePlantSummaryStatement.Bind(plantSummary.Name, plantSummary.Description, plantSummary.Id);
            session.Execute(statement);
            plants[id] = plantSummary;
        }

        public void Delete(System.Guid id)
        {
            var statement = deletePlantSummaryStatement.Bind(id);
            session.Execute(statement);
            plants.Remove(id);
        }
    }
}
