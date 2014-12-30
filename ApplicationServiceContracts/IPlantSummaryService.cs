using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public interface IPlantSummaryService
    {
        IEnumerable<PlantSummary> GetAllPlants();

        PlantSummary GetPlant(int id);

        PlantSummary Create();

        void Update(int id, PlantSummary plantSummary);

        void Delete(int id);
    }
}
