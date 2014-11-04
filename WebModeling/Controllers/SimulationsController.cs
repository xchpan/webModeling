using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebModeling.Models;

namespace WebModeling.Controllers
{
    public class SimulationsController : ApiController
    {
        private readonly List<Simulation> simulations = new List<Simulation>()
        {
            new Simulation()
            {
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Sim 1",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                CreateDatetime = DateTime.UtcNow,
                Creator = "Weiwei Li",
                Name = "Sim 2",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                CreateDatetime = DateTime.UtcNow,
                Creator = "Max Pan",
                Name = "Sim 3",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                CreateDatetime = DateTime.UtcNow,
                Creator = "Anita Pan",
                Name = "Sim 4",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
        };


        // GET api/simulations
        public IEnumerable<Simulation> GetAllSimulations()
        {
            return simulations;
        }

        // GET api/simulations/
        public Simulation GetSimulation(string name)
        {
            return simulations.SingleOrDefault(s => s.Name == name);
        }

        // POST api/simulations
        public void Post([FromBody]string value)
        {
        }

        // PUT api/simulations/Sim 1
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/simulations/Sim 1
        public void Delete(string name)
        {
            var simulation = GetSimulation(name);
            if (simulation != null)
            {
                simulations.Remove(simulation);
            }
        }
    }
}
