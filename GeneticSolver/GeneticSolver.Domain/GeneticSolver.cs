using GeneticSharp;
using GeneticSolver.Domain.Factories;
using GeneticSolver.Domain.Genetic;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Domain.Utils;
using Microsoft.Extensions.Logging;

namespace GeneticSolver.Domain
{
    public class GeneticSolver : IGeneticSolver
    {
        private readonly ILogger<GeneticSolver> _logger;
        private readonly IFemCalculationsPort _femCalculator;
        private readonly IGeneticAlgorithmFactory _algorithmFactory;
        private readonly ISolverProgressReporterPort _progress;

        private GeneticAlgorithm? _geneticAlgorithm;
        private bool _finished;
        public GeneticSolver(ILogger<GeneticSolver> logger, IFemCalculationsPort femCalculator, IGeneticAlgorithmFactory algorithmFactory , ISolverProgressReporterPort progress)
        {
            _logger = logger;
            _femCalculator = femCalculator;
            _algorithmFactory = algorithmFactory;
            _progress = progress;
        }

        public async ValueTask Start(GeneticSolverConfiguration configuration)
        {
            _geneticAlgorithm = _algorithmFactory.Create(configuration);
            _geneticAlgorithm.GenerationRan += (sender, e) => Task.Run(() => Calculate(configuration));

            var task = Task.Run(() =>
            {
                _geneticAlgorithm.Start();
                while (_geneticAlgorithm.TaskExecutor.IsRunning)
                {
                }
                _geneticAlgorithm.Stop();
            });

            await task;

            _finished = true;
            await Calculate(configuration);
        }

        private async ValueTask Calculate(GeneticSolverConfiguration configuration)
        {
            if (_geneticAlgorithm?.BestChromosome is not FloatingPointChromosome bestChromosome || bestChromosome.Fitness is null)
            {
                return;
            }
            var geometry = BeamGeometry.FromFloatingPoints(bestChromosome);
            var input = geometry.ToFemCalculationInput(configuration);

            var result = await _femCalculator.CalculateAsync(input);
            var notification = result.ToSolverProgress(geometry, _finished);
            await _progress.ReportProgress(notification);
        }

        
    }
}
