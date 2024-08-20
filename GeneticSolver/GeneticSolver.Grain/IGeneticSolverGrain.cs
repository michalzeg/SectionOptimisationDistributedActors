using Orleans.Concurrency;

namespace GeneticSolver.Grain
{
    public interface IGeneticSolverGrain : IGrainWithGuidKey
    {
        [OneWay]
        ValueTask Execute(GeneticSolverExecutionRequest request);
    }
}
