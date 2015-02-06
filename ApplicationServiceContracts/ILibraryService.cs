﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.ApplicationServices
{
    public interface ILibraryService
    {
        IEnumerable<Library> GetLibraries();

        Library CreateLibrary();

        void DeleteLibrary(Guid id);

        LibraryItem CreateFluidInLibrary(Guid id);

        LibraryItem CreatePortInLibrary(Guid id);

        LibraryItem CreateModelInLibrary(Guid id);
    }
}
