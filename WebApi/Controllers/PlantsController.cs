using System.Collections.Generic;
using System.Web.Http;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.WebApi.Controllers
{
    public class PlantsController : ApiController
    {
        private readonly IPlantSummaryService plantSummaryService;

        public PlantsController(IPlantSummaryService plantSummaryService)
        {
            this.plantSummaryService = plantSummaryService;
        }
        
        // GET api/Plants
        public IEnumerable<PlantSummary> GetAllPlants()
        {
            return plantSummaryService.GetAllPlants();
        }

        // GET api/Plants/
        public PlantSummary GetPlant(int id)
        {
            return plantSummaryService.GetPlant(id);
        }

        // POST api/Plants
        public PlantSummary Post()
        {
            return plantSummaryService.Create();
        }

        // PUT api/Plants/1
        public void Put(int id, PlantSummary plantSummary)
        {
            plantSummaryService.Update(id, plantSummary);
        }

        // DELETE api/Plants/1
        public void Delete(int id)
        {
            plantSummaryService.Delete(id);
        }
    }
}
