using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public class PlantSummaryService : IPlantSummaryService
    {
        private static int nextId = 4;

        private static readonly List<PlantSummary> PlantSummaries = new List<PlantSummary>()
        {
            new PlantSummary()
            {
                Id = 1,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Plant 1",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new PlantSummary()
            {
                Id = 2,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Weiwei Li",
                Name = "Plant 2",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new PlantSummary()
            {
                Id = 3,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Max Pan",
                Name = "Plant 3",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new PlantSummary()
            {
                Id = 4,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Anita Pan",
                Name = "Plant 4",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
        };

        public IEnumerable<PlantSummary> GetAllPlants()
        {
            return PlantSummaries;
        }

        public PlantSummary GetPlant(int id)
        {
            return PlantSummaries.SingleOrDefault(s => s.Id == id);
        }

        public PlantSummary Create()
        {
            var plant = new PlantSummary()
            {
                Id = Interlocked.Increment(ref nextId),
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Plant " + nextId,
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            };
            PlantSummaries.Add(plant);

            return plant;
        }

        public void Update(int id, PlantSummary plantSummary)
        {
            for (int i = 0; i < PlantSummaries.Count; i++)
            {
                if (PlantSummaries[i].Id == id)
                {
                    PlantSummaries[i] = plantSummary;
                    return;
                }
            }

            throw new ArgumentException("PlantSummary id doesn't exist.");
        }

        public void Delete(int id)
        {
            var plant = GetPlant(id);
            if (plant != null)
            {
                PlantSummaries.Remove(plant);
            }
        }
    }
}
