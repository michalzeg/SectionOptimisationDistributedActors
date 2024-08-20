using FemCalculator.Grain;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Silo.Utils;
using Infrastructure.Shared.Executors;
using Microsoft.Extensions.Configuration;

namespace GeneticSolver.Silo.Adapters
{
    public class FemCalculatorAdapter : IFemCalculationsPort
    {
        private readonly ILogger<FemCalculatorAdapter> _logger;
        private readonly IStatelessGrainExecutor _grainExecutor;
        public FemCalculatorAdapter(ILogger<FemCalculatorAdapter> logger, IStatelessGrainExecutor grainExecutor)
        {
            _logger = logger;
            _grainExecutor = grainExecutor;
        }

        public async ValueTask<FemCalculationResult> CalculateAsync(FemCalculationInput input)
        {
            try
            {
                var calculationRequest = input.ToCalculationRequest();
                var calculationResult = await _grainExecutor.ExecuteGrainMethod<IFemCalculatorGrain, CalculationResponse>(async e => await e.Calculate(calculationRequest));
                return calculationResult.ToFemCalculationResult();
            } catch(Exception ex)
            {
                _logger.LogError(ex, "FemCalculator adapter error");
                return new() { MaxStress = default, TotalWeight = double.MinValue };
            }
        }
    }
}
