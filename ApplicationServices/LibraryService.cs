using System;
using System.Collections.Generic;
using System.Linq;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public class LibraryService : ILibraryService
    {
        private static readonly List<Library> libraries;

        static LibraryService()
        {
            libraries = new List<Library>();

            var fluidLib = new Library()
            {
                Name = "Fluids"
            };
            var fluid = new FluidType(Guid.NewGuid())
            {
                Name = "Gas",
                Icon = "/images/icons/gas.jpg",
                Description = string.Empty,
                PhaseMethod = PhaseMethods.Vapor,
                SystemMethod = SystemMethods.SRK,
                ThermoType = ThermoTypes.Air
            };
            fluidLib.Add(fluid);
            fluid = new FluidType(Guid.NewGuid())
            {
                Name = "Water",
                Icon = "/images/icons/liquid.jpg",
                Description = string.Empty,
                PhaseMethod = PhaseMethods.Liquid,
                SystemMethod = SystemMethods.SRK,
                ThermoType = ThermoTypes.Air
            };
            fluidLib.Add(fluid);

            libraries.Add(fluidLib);

            var steamLib = new Library()
            {
                Name = "Steam Lib"
            };

            var model = new ModelTemplate(Guid.NewGuid())
            {
                Name = "Source",
                Icon = "/images/icons/pipe.jpg"
            };
            steamLib.Add(model);
            model = new ModelTemplate(Guid.NewGuid())
            {
                Name = "Sink",
                Icon = "/images/icons/pipe.jpg"
            };
            steamLib.Add(model);
            libraries.Add(steamLib);

            var flareLib = new Library(Guid.NewGuid())
            {
                Name = "Flare Lib"
            };
            model = new ModelTemplate(Guid.NewGuid())
            {
                Name = "Valve",
                Icon = "/images/icons/valve.jpg",
            };
            flareLib.Add(model);
            model = new ModelTemplate(Guid.NewGuid())
{
    Name = "Pipe",
    Icon = "/images/icons/pipe.jpg",
};
            flareLib.Add(model);
            var port = new PortTemplate(Guid.NewGuid())
            {
                Name = "Fluid Port",
                Icon = "/images/icons/port.jpg"
            };
            flareLib.Add(port);

            libraries.Add(flareLib);
        }

        public IEnumerable<Library> GetLibraries()
        {
            return libraries.AsEnumerable();
        }

        public Library CreateLibrary()
        {
            int count = libraries.Count + 1;
            var name = "Lib " + count;
            while (libraries.FirstOrDefault(l => l.Name == name) != null)
            {
                name = "Lib " + (++count);
            }
            var lib = new Library(Guid.NewGuid())
            {
                Name = name
            };
            libraries.Add(lib);
            return lib;
        }

        public void DeleteLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            if (lib != null)
            {
                libraries.Remove(lib);
            }
            else
            {
                throw new ArgumentException("The library id doesn't exist.");
            }
        }

        public FluidType CreateFluidInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Fluid " + i;
            while (lib.ContainsFluidName(name))
            {
                name = "Fluid" + (++i);
            }

            var fluid = new FluidType(Guid.NewGuid()) { Icon = "/images/icons/liquid.jpg", Name = name };
            lib.Add(fluid);
            return fluid;
        }

        public PortTemplate CreatePortInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Port " + i;
            while (lib.ContainsPortName(name))
            {
                name = "Port" + (++i);
            }

            var port = new PortTemplate(Guid.NewGuid()) { Icon = "/images/icons/port.jpg", Name = name };
            lib.Add(port);
            return port;
        }

        public ModelTemplate CreateModelInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Model " + i;
            while (lib.ContainsModelName(name))
            {
                name = "Model" + (++i);
            }

            var model = new ModelTemplate(Guid.NewGuid()) { Icon = "/images/icons/valve.jpg", Name = name };
            lib.Add(model);
            return model;
        }

        private Library FindLibrary(Guid id)
        {
            return libraries.FirstOrDefault(l => l.Id == id);
        }
    }
}
