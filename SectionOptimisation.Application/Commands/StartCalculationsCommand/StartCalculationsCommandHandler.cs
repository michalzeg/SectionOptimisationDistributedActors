using Coordinator.Grain;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SectionOptimisation.Application.Commands.StartCalculationsCommand
{
    public class StartCalculationsCommandHandler : IRequestHandler<StartCalculationsExtendedCommand>
    {
        private readonly ILogger<StartCalculationsCommandHandler> _logger;
        private readonly IGrainFactory _grainFactory;

        public StartCalculationsCommandHandler(ILogger<StartCalculationsCommandHandler> logger, IGrainFactory grainFactory)
        {
            _logger = logger;
            _grainFactory = grainFactory;
        }
        public async Task Handle(StartCalculationsExtendedCommand request, CancellationToken cancellationToken)
        {
            var startCalculationRequest = new StartCalculationsRequest()
            {
                BeamLength = request.Length,
                ExternalLoad = request.Load,
                ModulusOfElasticity = request.ModulusOfElasticity,
                CalculationId = request.CalculationId,
                SelectionType = request.Selection,
                Spans = request.Spans,
                MaxStress = request.MaxStress,
                CrossoverType = request.Crossover,
                MaxPopulation = request.Population[1],
                MinPopulation = request.Population[0],
                MutationType = request.Mutation,
                Termination = request.Termination,
                Weight = request.Weight,
                Label = request.Label
            };

            var coordinationGrain = _grainFactory.GetGrain<ICoordinatorGrain>(Constants.Coordinator);
            await coordinationGrain.StartCalculations(startCalculationRequest);
        }
    }
}
