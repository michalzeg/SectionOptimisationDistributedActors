using Coordinator.Grain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SectionOptimisation.Application.Commands.RemoveCalculationsCommand
{
    public class RemoveCalculationsCommandHandler : IRequestHandler<RemoveCalculationsCommand>
    {
        private readonly ILogger<RemoveCalculationsCommandHandler> _logger;
        private readonly IGrainFactory _grainFactory;

        public RemoveCalculationsCommandHandler(ILogger<RemoveCalculationsCommandHandler> logger, IGrainFactory grainFactory)
        {
            _logger = logger;
            _grainFactory = grainFactory;
        }
        public async Task Handle(RemoveCalculationsCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var coordinationGrain = _grainFactory.GetGrain<ICoordinatorGrain>(Constants.Coordinator);
                await coordinationGrain.RemoveCalculations(request.CalculationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during removing calculations");
                throw;
            }

        }
    }
}
