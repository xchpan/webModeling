using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xpan.plantDesign.Repository;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public class PlantSummaryService : IPlantSummaryService
    {
        private readonly IPlantSummaryRepository repository;

        public PlantSummaryService(IPlantSummaryRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PlantSummary> GetAllPlants()
        {
            return repository.GetAllPlants();
        }

        public PlantSummary GetPlant(Guid id)
        {
            return repository.GetPlant(id);
        }

        private static int count = 2;
             
        public PlantSummary Create()
        {
            Guid id = Guid.NewGuid();
            var plant = new PlantSummary()
            {
                Id = id,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Plant " + count++,
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            };
            repository.Add(plant);

            return plant;
        }

        public void Update(Guid id, PlantSummary plantSummary)
        {
            repository.Update(id, plantSummary);
        }

        public void Delete(Guid id)
        {
           repository.Delete(id);
        }
    }
}
