using System.Collections.Generic;
using System.Linq;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public class LibraryService : ILibraryService
    {
        private static readonly List<Library> libraries = new List<Library>()
        {
            new Library(name: "Fluids", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Gas", Icon = "/images/icons/gas.jpg"},
                new LibraryItem() {Name = "Water", Icon = "/images/icons/liquid.jpg"}
            }),
            new Library(name: "Steam Lib", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Source", Icon = "/images/icons/pipe.jpg"},
                new LibraryItem() {Name = "Sink", Icon = "/images/icons/pipe.jpg"}
          
            }),
            new Library(name: "Flare Lib", items:new List<LibraryItem>()
            {
                new LibraryItem() {Name = "Valve", Icon = "/images/icons/valve.jpg"},
                new LibraryItem() {Name = "Pipe", Icon = "/images/icons/pipe.jpg"}   
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
    }
}
