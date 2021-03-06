﻿using System;
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

        PlantSummary GetPlant(Guid id);

        PlantSummary Create();

        void Update(Guid id, PlantSummary plantSummary);

        void Delete(Guid id);
    }
}
