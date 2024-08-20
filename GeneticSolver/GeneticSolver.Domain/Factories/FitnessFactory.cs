using GeneticSharp;
using GeneticSolver.Domain.Genetic;
using GeneticSolver.Domain.Ports;
using Microsoft.Extensions.Logging;

namespace GeneticSolver.Domain.Factories
{
    public class FitnessFactory : IFitnessFactory
    {
        private readonly ILogger<FitnessFactory> _logger;
        private readonly ISolverProgressReporterPort _solverProgressReporter;
        private readonly IFitnessEvaluationPort _fitnessEvaluation;
        private readonly IFemCalculationsPort _femCalculator;

        public FitnessFactory(ILogger<FitnessFactory> logger, ISolverProgressReporterPort solverProgressReporter, IFitnessEvaluationPort fitnessEvaluation, IFemCalculationsPort femCalculator)
        {
            _logger = logger;
            _solverProgressReporter = solverProgressReporter;
            _fitnessEvaluation = fitnessEvaluation;
            _femCalculator = femCalculator;
        }

        public IFitness Create(GeneticSolverConfiguration configuration)
        {
            var fitness = new Fitness(_fitnessEvaluation, _femCalculator, configuration);
            var reportingFitness = new ReportingFitness(fitness, _solverProgressReporter);
            var errorHandlingFitness = new ErrorHandlingFitness(_logger, reportingFitness);
            return errorHandlingFitness;
        }
    }
}
