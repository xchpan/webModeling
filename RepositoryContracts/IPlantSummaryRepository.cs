using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.Repository
{
    public interface IPlantSummaryRepository
    {
        IEnumerable<PlantSummary> GetAllPlants();

        PlantSummary GetPlant(Guid id);

        void Add(PlantSummary plantSummary);

        void Update(Guid id, PlantSummary plantSummary);

        void Delete(Guid id);
    }
}
