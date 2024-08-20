using Coordinator.Grain;
using Coordinator.Silo.State;
using Coordinator.Silo.Utils;
using GeneticSolver.Grain;
using GeneticSolver.Shared.Types;
using Orleans.Runtime;
namespace Coordinator.Silo
{
    public sealed class CoordinatorGrain : Orleans.Grain, ICoordinatorGrain
    {
        private readonly ILogger<CoordinatorGrain> _logger;
        private readonly IGrainFactory _grainFactory;
        private readonly IPersistentState<CoordinatorState> _state;

        public CoordinatorGrain(ILogger<CoordinatorGrain> logger, IGrainFactory grainFactory, [PersistentState(Constants.StorageName,Constants.StorageName)] IPersistentState<CoordinatorState> state)
        {
            _logger = logger;
            _grainFactory = grainFactory;
            _state = state;
        }
        public async ValueTask StartCalculations(StartCalculationsRequest request)
        {
            var configuration = request.ToGeneticSolverExecutionRequest();
            var grain = _grainFactory.GetGrain<IGeneticSolverGrain>(request.CalculationId);
            await grain.Execute(configuration);

            var calculationState = new CalculationsState() { Input = request };
            _state.State.CalculationsState.Add(request.CalculationId, calculationState);
            await _state.WriteStateAsync();
        }

        public async ValueTask<ProgressResponse> GetProgress(Guid calculationId)
        {
            await _state.ReadStateAsync();

            if (!_state.State.CalculationsState.TryGetValue(calculationId, out var value))
            {
                _logger.LogWarning("State for id: {calculationsId} does not exists", calculationId);
                return new ProgressResponse() { ProgressDetails = [], StartedAt = default };
            }

            return new ProgressResponse()
            {
                ProgressDetails = value.Results,
                StartedAt = value.StartedAt,
            };
        }

        public async ValueTask ReportProgress(Guid calculationId, ProgressDetails request)
        {
            if (!_state.State.CalculationsState.TryGetValue(calculationId, out var value))
            {
                _logger.LogWarning("Calculations state for operation {calculationId} does not exist", calculationId);
                return;
            }

            value.Results.Add(request);
            await _state.WriteStateAsync();
        }

        public ValueTask<CalculationsListResponse> GetCalculationsList()
        {
            var result = _state.State.CalculationsState.Select(e=>e.Value.Input).ToList();
            return ValueTask.FromResult(new CalculationsListResponse() { CalculationInputs = result });
        }

        public async ValueTask RemoveCalculations(Guid calculationId)
        {
            if (!_state.State.CalculationsState.TryGetValue(calculationId, out _))
            {
                _logger.LogWarning("State for id: {calculationsId} does not exists", calculationId);
                return;
            }

            _state.State.CalculationsState.Remove(calculationId);
            await _state.WriteStateAsync();
        }
    }
}
