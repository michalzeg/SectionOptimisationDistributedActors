using FemCalculator.Domain;
using FemCalculator.Domain.Models;
using FemCalculator.Grain;
using FemCalculator.Silo.Utils;
using Orleans.Concurrency;

namespace FemCalculator.Silo
{
    [StatelessWorker]
    public sealed class FemCalculatorGrain : Orleans.Grain, IFemCalculatorGrain
    {
        private readonly IFemCalculator _femCalculator;

        public FemCalculatorGrain(IFemCalculator femCalculator)
        {
            _femCalculator = femCalculator;
        }

        public ValueTask<CalculationResponse> Calculate(CalculationRequest request)
        {
            var calculationInput = request.ToFemCalculationInput();

            var calculationResult = _femCalculator.Calculate(calculationInput);
            var result = calculationResult.ToCalculationResponse();
            return ValueTask.FromResult(result);
        }
    }
}
