using GeneticSharp;
using GeneticSolver.Domain.Ports;

namespace GeneticSolver.Domain.Genetic
{
    public sealed class ReportingFitness : IFitness
    {
        private int _chromosomesEvaluated;
        private readonly IFitness _decoratedFitness;
        private readonly ISolverProgressReporterPort _solverProgress;

        public ReportingFitness(IFitness decoratedFitness, ISolverProgressReporterPort solverProgress)
        {
            _decoratedFitness = decoratedFitness;
            _solverProgress = solverProgress;
        }

        public double Evaluate(IChromosome chromosome)
        {
            Interlocked.Increment(ref _chromosomesEvaluated);
            _solverProgress.ReportEvaluations(new() { ChromosomesEvaluated = _chromosomesEvaluated });
            return _decoratedFitness.Evaluate(chromosome);
        }
    }
}
