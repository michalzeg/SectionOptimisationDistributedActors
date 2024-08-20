using Orleans.Concurrency;

namespace FitnessEvaluator.Grain
{
    public interface IFitnessEvaluatorGrain : IGrainWithGuidKey
    {
        ValueTask<EvaluationResponse> Evaluate(EvaluationRequest request);
    }
}
