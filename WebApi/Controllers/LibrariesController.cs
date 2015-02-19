using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ModelViewModelConverterContracts;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.Domain.SharedLibraries;
using xpan.plantDesign.Domain.SharedLibraries.FluidTemplate;
using xpan.plantDesign.Domain.SharedLibraries.VariableTemplate;
using xpan.plantDesign.Repository;
using xpan.plantDesign.ViewModels;

namespace xpan.plantDesign.WebApi.Controllers
{
    public class LibrariesController : ApiController
    {
        private readonly ILibraryService libraryService;
        private readonly IVariableTypeRepository variableTypeRepository;
        private readonly IFluidComponentTypeRepository fluidComponentTypeRepository;
        private readonly IModelToViewModel modelToViewModelConverter;

        public LibrariesController(ILibraryService libraryService, IVariableTypeRepository variableTypeRepository, IFluidComponentTypeRepository fluidComponentTypeRepository,
            IModelToViewModel modelToViewModelConverter)
        {
            this.libraryService = libraryService;
            this.variableTypeRepository = variableTypeRepository;
            this.fluidComponentTypeRepository = fluidComponentTypeRepository;
            this.modelToViewModelConverter = modelToViewModelConverter;
        }

        public IEnumerable<LibraryViewModel> GetLibraries()
        {
            var libraries = libraryService.GetLibraries();

            var viewModels = new List<LibraryViewModel>();
            foreach (var library in libraries)
            {
                var viewModel = new LibraryViewModel
                {
                    Id = library.Id,
                    Name = library.Name
                };
                var fluids = GenerateFluidsViewModel(library);
                var ports = GeneratePortsViewModel(library);
                var models = GenerateModelsViewModel(library);

                viewModel.Items = fluids.OfType<LibraryItemViewModel>().Union(ports).Union(models);
                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        private List<ModelTemplateViewModel> GenerateModelsViewModel(Library library)
        {
            var models = new List<ModelTemplateViewModel>();
            foreach (var modelTemplate in library.ModelTemplates)
            {
                models.Add(modelToViewModelConverter.ToViewModel(modelTemplate));
            }

            return models;
        }

        private List<PortTemplateViewModel> GeneratePortsViewModel(Library library)
        {
            var ports = new List<PortTemplateViewModel>();
            foreach (var portTemplate in library.PortTemplates)
            {
                var port = modelToViewModelConverter.ToViewModel(portTemplate);
                ports.Add(port);
            }
            return ports;
        }

        private List<FluidTypeViewModel> GenerateFluidsViewModel(Library library)
        {
            var fluids = new List<FluidTypeViewModel>();
            foreach (var fluidTemplate in library.FluidTemplates)
            {
                var fluid = modelToViewModelConverter.ToViewModel(fluidTemplate);
                fluids.Add(fluid);
            }
            return fluids;
        }

        [HttpPost]
        public Library CreateLibrary()
        {
            return libraryService.CreateLibrary();
        }

        public void DeleteLibrary(Guid id)
        {
            libraryService.DeleteLibrary(id);
        }

        [Route("api/libraries/{id}/fluid")]
        [HttpPost]
        public FluidTypeViewModel CreateFluid(Guid id)
        {
            var fluid = libraryService.CreateFluidInLibrary(id);
            return modelToViewModelConverter.ToViewModel(fluid);
        }

        [Route("api/libraries/{id}/port")]
        [HttpPost]
        public PortTemplateViewModel CreatePort(Guid id)
        {
            var port = libraryService.CreatePortInLibrary(id);
            return modelToViewModelConverter.ToViewModel(port);
        }

        [Route("api/libraries/{id}/port")]
        [HttpPut]
        public void UpdatePort(Guid id, PortTemplateViewModel port)
        {
            var portTemplate = new PortTemplate(port.Id)
            {
                Description = port.Description,
                Icon = port.Icon,
                Name = port.Name
            };

            foreach (var variable in port.Variables)
            {
                var variableDescription = portTemplate.AddVariable(variable.Name,
                    variableTypeRepository.FindVariableType(variable.VariableTypeName));
                variableDescription.OverridenMin = variable.OverridenMin;
                variableDescription.OverridenMax = variable.OverridenMax;
                variableDescription.OverridenDefaultValue = variable.OverridenDefaultValue;
            }

            libraryService.UpdatePort(libraryId:id, port:portTemplate);
        }

        [Route("api/libraries/{id}/Model")]
        [HttpPost]
        public ModelTemplateViewModel CreateModel(Guid id)
        {
            var model = libraryService.CreateModelInLibrary(id);
            return modelToViewModelConverter.ToViewModel(model);
        }

        [Route("api/libraries/variableTypes")]
        [HttpGet]
        public IEnumerable<VariableCategory> GetVariableCategories()
        {
            return variableTypeRepository.VariableCategories;
        }

        [Route("api/libraries/fluidComponentTypes")]
        [HttpGet]
        public IEnumerable<FluidComponentTypesViewModel.FluidComponentCategory> GetFluidComponentTypes()
        {
            var viewModel = new FluidComponentTypesViewModel();
            foreach (var componentType in fluidComponentTypeRepository.FluidComponentTypes)
            {
                viewModel.AddFluidComponentType(componentType.Categories, componentType.Subcategories, componentType.Name, componentType.Description);
            }

            return viewModel.FluidComponentCategories;
        }
    }
}
