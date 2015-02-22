using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelViewModelConverterContracts;
using xpan.plantDesign.ViewModels;

namespace ModelViewModelConverters
{
    public class ModelToViewModel : IModelToViewModel
    {
        public xpan.plantDesign.ViewModels.FluidTypeViewModel ToViewModel(xpan.plantDesign.Domain.SharedLibraries.FluidTemplate.FluidType fluid)
        {
            var viewModel = new FluidTypeViewModel()
            {
                Description = fluid.Description,
                Icon = fluid.Icon,
                Id = fluid.Id,
                Name = fluid.Name,
                PhaseMethod = fluid.PhaseMethod.ToString(),
                SystemMethod = fluid.SystemMethod,
                LiquidDensityMethod = fluid.LiquidDensityMethod.ToString().Replace('_', ' '),
                StartingPressureValue = fluid.StartingPressureInkPa,
                StartingTemprature = fluid.StartingTempratureInK,
            };
            var fluidComponents = new List<FluidComponentViewModel>();
            foreach (var fluidComponent in fluid.Components)
            {
                fluidComponents.Add(new FluidComponentViewModel()
                {
                    ShortName = fluidComponent.Name,
                    FullName = fluidComponent.Description,
                    StartingPercentage = fluidComponent.StartingComposition
                });
            }
            viewModel.FluidComponents = fluidComponents;

            return viewModel;
        }

        public xpan.plantDesign.ViewModels.PortTemplateViewModel ToViewModel(xpan.plantDesign.Domain.SharedLibraries.PortTemplate port)
        {
            var viewModel = new PortTemplateViewModel()
            {
                Id = port.Id,
                Name = port.Name,
                Description = port.Description,
                Icon = port.Icon
            };

            var parameters = new List<ParameterTemplateViewModel>();
            foreach (var parameterDescription in port.Parameters)
            {
                var parameter = new ParameterTemplateViewModel()
                {
                    Name = parameterDescription.Name,
                    ParameterTypeName = parameterDescription.ParameterType.Name,
                    OverridenDefaultValue = parameterDescription.OverridenDefaultValue,
                    OverridenMax = parameterDescription.OverridenMax,
                    OverridenMin = parameterDescription.OverridenMin,
                    RequireUserToProvideInitialValue = parameterDescription.RequireUserToProvideInitialValue
                };
                parameters.Add(parameter);
            }
            viewModel.Parameters = parameters;

            var variables = new List<VariableTemplateViewModel>();
            foreach (var variableTemplate in port.Variables)
            {
                var variable = new VariableTemplateViewModel
                {
                    Name = variableTemplate.Name,
                    VariableTypeName = variableTemplate.VariableType.Name,
                    IsFixedValue = variableTemplate.IsFixedValue,
                    RequireUserToProvideInitialValue = variableTemplate.RequireUserToProvideInitialValue,
                    OverridenDefaultValue = variableTemplate.OverridenDefaultValue,
                    OverridenMax = variableTemplate.OverridenMax,
                    OverridenMin = variableTemplate.OverridenMin
                };
                variables.Add(variable);
            }
            viewModel.Variables = variables;

            var fluids = new Dictionary<string, string>();
            var fluid = port.Fluids;
            while (fluid.MoveNext())
            {
                fluids.Add(fluid.Current.Key, fluid.Current.Value.Name);
            }
            viewModel.Fluids = fluids;

            return viewModel;
        }

        public xpan.plantDesign.ViewModels.ModelTemplateViewModel ToViewModel(xpan.plantDesign.Domain.SharedLibraries.ModelTemplate model)
        {
            var viewModel = new ModelTemplateViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Icon = model.Icon
            };
            var parameters = new List<ParameterTemplateViewModel>();
            foreach (var parameterDescription in model.Parameters)
            {
                var parameter = new ParameterTemplateViewModel()
                {
                    Name = parameterDescription.Name,
                    ParameterTypeName = parameterDescription.ParameterType.Name,
                    OverridenDefaultValue = parameterDescription.OverridenDefaultValue,
                    OverridenMax = parameterDescription.OverridenMax,
                    OverridenMin = parameterDescription.OverridenMin,
                    RequireUserToProvideInitialValue = parameterDescription.RequireUserToProvideInitialValue
                };
                parameters.Add(parameter);
            }
            viewModel.Parameters = parameters;
            viewModel.Ports = Enumerable.Empty<PortViewModel>();
            viewModel.Conditions = Enumerable.Empty<ConditionTemplateViewModel>();
            viewModel.Variables = Enumerable.Empty<ConditionedVariableTemplateViewModel>();
            viewModel.Submodels = Enumerable.Empty<SubmodelTemplateViewModel>();
            viewModel.ParameterConnections = Enumerable.Empty<ParameterConnectionViewModel>();
            viewModel.VariableSharings = Enumerable.Empty<VariableSharingViewModel>();
            return viewModel;
        }
    }
}
