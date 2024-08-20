using FitnessEvaluator.Domain.Specifications;
using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain
{

    public class FitnessEvaluator : IFitnessEvaluator
    {
        private readonly ISpecification<FitnessDetails>[] _specifications;

        public FitnessEvaluator(ISpecification<FitnessDetails>[] specifications)
        {
            _specifications = specifications;
        }
        public ValueTask<EvaluationResult> Evaluate(FitnessDetails fitnessDetails)
        {
            var isNotSatisfied = _specifications.Any(e => !e.IsSatisfiedBy(fitnessDetails));
            if (isNotSatisfied)
            {
                return ValueTask.FromResult(EvaluationResult.Failed);
            }

            var factor = - fitnessDetails.TotalWeight;
            return ValueTask.FromResult(new EvaluationResult() { Factor = factor });
        }
    }
}
