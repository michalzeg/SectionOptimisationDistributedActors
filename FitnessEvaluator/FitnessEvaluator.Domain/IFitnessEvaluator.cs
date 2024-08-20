using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain
{
    public interface IFitnessEvaluator
    {
        ValueTask<EvaluationResult> Evaluate(FitnessDetails fitnessDetails);
    }
}
