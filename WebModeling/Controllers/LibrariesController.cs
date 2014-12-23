using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using WebModeling.Models;

namespace WebModeling.Controllers
{
    public class LibrariesController : ApiController
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
    }
}
