using GeneticSharp;
using Microsoft.Extensions.Logging;

namespace GeneticSolver.Domain.Genetic
{
    public sealed class ErrorHandlingFitness : IFitness
    {
        private readonly ILogger _logger;
        private readonly IFitness _decoratedFitness;

        public ErrorHandlingFitness(ILogger logger, IFitness decoratedFitness)
        {
            _logger = logger;
            _decoratedFitness = decoratedFitness;
        }
        public double Evaluate(IChromosome chromosome)
        {
            try
            {
                return _decoratedFitness.Evaluate(chromosome);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Fitness exception");
                return double.MinValue;
            }
        }
    }
}
