using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebModeling.Models;

namespace WebModeling.Controllers
{
    public class SimulationsController : ApiController
    {
        private static int id = 4;

        private static readonly List<Simulation> simulations = new List<Simulation>()
        {
            new Simulation()
            {
                Id = 1,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Sim 1",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                Id = 2,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Weiwei Li",
                Name = "Sim 2",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                Id = 3,
                CreateDatetime = DateTime.UtcNow,
                Creator = "Max Pan",
                Name = "Sim 3",
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            },
            new Simulation()
            {
                Id = 4,
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
        public Simulation GetSimulation(int id)
        {
            return simulations.SingleOrDefault(s => s.Id == id);
        }

        // POST api/simulations
        public Simulation Post([FromBody]string value)
        {
            var simulation = new Simulation()
            {
                Id = Interlocked.Increment(ref id),
                CreateDatetime = DateTime.UtcNow,
                Creator = "Xiuchuan Pan",
                Name = "Sim " + id,
                Description = string.Empty,
                LastModifiedDateTime = DateTime.UtcNow
            };
            simulations.Add(simulation);

            return simulation;
        }

        // PUT api/simulations/1
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        public void Put(int id, Simulation simulation)
        {
            for (int i = 0; i < simulations.Count; i++)
            {
                if (simulations[i].Id == id)
                {
                    simulations[i] = simulation;
                    return;
                }
            }

            throw new ArgumentException("Simulation id doesn't exist.");
        }

        // DELETE api/simulations/1
        public void Delete(int id)
        {
            var simulation = GetSimulation(id);
            if (simulation != null)
            {
                simulations.Remove(simulation);
            }
        }
    }
}
