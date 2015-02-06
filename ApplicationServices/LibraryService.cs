using System;
using System.Collections.Generic;
using System.Linq;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public class LibraryService : ILibraryService
    {
        private const string fluidType = "Fluid";
        private const string portType = "Port";
        private const string modelType = "Model";

        private static readonly List<Library> libraries = new List<Library>()
        {
            new Library(name: "Fluids", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Gas", Type="Fluid", Icon = "/images/icons/gas.jpg"},
                new LibraryItem() {Name = "Water", Type="Fluid", Icon = "/images/icons/liquid.jpg"}
            }),
            new Library(name: "Steam Lib", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Source", Type="Model", Icon = "/images/icons/pipe.jpg"},
                new LibraryItem() {Name = "Sink", Type="Model", Icon = "/images/icons/pipe.jpg"}
          
            }),
            new Library(name: "Flare Lib", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Valve", Type="Model", Icon = "/images/icons/valve.jpg"},
                new LibraryItem() {Name = "Pipe", Type="Model", Icon = "/images/icons/pipe.jpg"},
                new LibraryItem() {Name = "Fluid Port", Type = "Port", Icon = "/images/icons/port.jpg"}
            })
        };

        public IEnumerable<Library> GetLibraries()
        {
            return libraries.AsEnumerable();
        }

        public Library CreateLibrary()
        {
            var name = "Lib " + (libraries.Count + 1);
            var lib = new Library(name: name, items: Enumerable.Empty<LibraryItem>());
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

        public LibraryItem CreateFluidInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Fluid " + i;
            while (lib.Items.FirstOrDefault(item => item.Name == name) != null)
            {
                name = "Fluid" + (++i);
            }

            var fluid = new LibraryItem() {Icon = "/images/icons/liquid.jpg", Name = name, Type = fluidType};
            lib.Add(fluid);
            return fluid;
        }

        public LibraryItem CreatePortInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Port " + i;
            while (lib.Items.FirstOrDefault(item => item.Name == name) != null)
            {
                name = "Port" + (++i);
            }

            var port = new LibraryItem() {Icon = "/images/icons/port.jpg", Name = name, Type = portType};
            lib.Add(port);
            return port;
        }

        public LibraryItem CreateModelInLibrary(Guid id)
        {
            var lib = FindLibrary(id);
            int i = 1;
            var name = "Model " + i;
            while (lib.Items.FirstOrDefault(item => item.Name == name) != null)
            {
                name = "Model" + (++i);
            }

            var model = new LibraryItem() {Icon = "/images/icons/valve.jpg", Name = name, Type = modelType};
            lib.Add(model);
            return model;
        }

        private Library FindLibrary(Guid id)
        {
            return libraries.FirstOrDefault(l => l.Id == id);
        }
    }
}
