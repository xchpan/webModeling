using System;
using System.Collections.Generic;
using System.Linq;

namespace xpan.plantDesign.ViewModels
{
    public class Library
    {
        private readonly Guid id;
        private string name;
        private List<LibraryItem>  items = new List<LibraryItem>();

        public Library(string name, IEnumerable<LibraryItem> items)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.items.AddRange(items);
        }

        public Guid Id { get { return id; } }

        public string Name { get { return name; } }

        public IEnumerable<LibraryItem> Items
        {
            get { return items.AsEnumerable(); }
        }
    }
}