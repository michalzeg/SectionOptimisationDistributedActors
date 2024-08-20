using GeneticSharp;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Domain.Utils;

namespace GeneticSolver.Domain.Genetic
{
    public sealed class Fitness : IFitness
    {
        private readonly IFitnessEvaluationPort _fitnessEvaluation;
        private readonly IFemCalculationsPort _femCalculator;
        private readonly GeneticSolverConfiguration _configuration;

        public Fitness(IFitnessEvaluationPort fitnessEvaluation, IFemCalculationsPort femCalculator, GeneticSolverConfiguration configuration)
        {
            _fitnessEvaluation = fitnessEvaluation;
            _femCalculator = femCalculator;
            _configuration = configuration;
        }

        public double Evaluate(IChromosome chromosome)
        {

            if (chromosome is not FloatingPointChromosome bestChromosome)
            {
                return double.MinValue;
            }
            var geometry = BeamGeometry.FromFloatingPoints(bestChromosome);
            var input = geometry.ToFemCalculationInput(_configuration);
            var calculationResult = _femCalculator.CalculateAsync(input).GetAwaiter().GetResult();
            var evaluation = calculationResult.ToEvaluation(geometry, _configuration);
            var evaluationResult = _fitnessEvaluation.Evaluate(evaluation).GetAwaiter().GetResult();

            return evaluationResult.Factor;
        }
    }
}
