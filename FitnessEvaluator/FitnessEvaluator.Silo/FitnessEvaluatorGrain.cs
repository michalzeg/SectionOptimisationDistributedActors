using FitnessEvaluator.Domain;
using FitnessEvaluator.Grain;
using FitnessEvaluator.Silo.Utils;
using Orleans.Concurrency;

namespace FitnessEvaluator.Silo
{
    [StatelessWorker]
    public sealed class FitnessEvaluatorGrain : Orleans.Grain, IFitnessEvaluatorGrain
    {
        private readonly ILogger<FitnessEvaluatorGrain> _logger;
        private readonly IFitnessEvaluator _fitnessEvaluator;

        public FitnessEvaluatorGrain(ILogger<FitnessEvaluatorGrain> logger, IFitnessEvaluator fitnessEvaluator)
        {
            _logger = logger;
            _fitnessEvaluator = fitnessEvaluator;
        }

        public async ValueTask<EvaluationResponse> Evaluate(EvaluationRequest request)
        {
            var details = request.ToFitnessDetails();
            var evaluationResult = await _fitnessEvaluator.Evaluate(details);

            return new EvaluationResponse()
            {
                Factor = evaluationResult.Factor
            };
        }
    }
}
