using FitnessEvaluator.Grain;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Silo.Utils;
using Infrastructure.Shared.Executors;

namespace GeneticSolver.Silo.Adapters
{
    public class FitnessEvaluationAdapter : IFitnessEvaluationPort
    {
        private readonly ILogger<FemCalculatorAdapter> _logger;
        private readonly IStatelessGrainExecutor _grainExecutor;
        public FitnessEvaluationAdapter(ILogger<FemCalculatorAdapter> logger, IStatelessGrainExecutor grainExecutor)
        {
            _logger = logger;
            _grainExecutor = grainExecutor;
        }

        public async ValueTask<EvaluationResult> Evaluate(Evaluation evaluation)
        {
            try
            {
                var request = evaluation.ToEvaluationRequest();
                var evaluationResult = await _grainExecutor.ExecuteGrainMethod<IFitnessEvaluatorGrain, EvaluationResponse>(async e => await e.Evaluate(request));
                var result = new EvaluationResult() { Factor = evaluationResult.Factor };
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fitness evaluator exception");
                return new EvaluationResult() { Factor = double.MinValue };
            }
        }

    }

}
