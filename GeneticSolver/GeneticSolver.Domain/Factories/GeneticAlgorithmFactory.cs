using GeneticSharp;
using GeneticSolver.Domain.Builders;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Domain.Utils;
using GeneticSolver.Shared.Types;

namespace GeneticSolver.Domain.Factories
{
    public class GeneticAlgorithmFactory : IGeneticAlgorithmFactory
    {
        private readonly IFitnessFactory _fitnessFactory;

        public GeneticAlgorithmFactory(IFitnessFactory fitnessFactory)
        {
            _fitnessFactory = fitnessFactory;
        }

        public GeneticAlgorithm Create(GeneticSolverConfiguration configuration)
        {
            var chromosome = ChromosomeBuilder.Create();

            var population = new Population(configuration.MinPopulation, configuration.MaxPopulation, chromosome);

            var mutation = GetMutation(configuration.MutationType);
            var selection = GetSelection(configuration.SelectionType);
            var crossover = GetCrossover(configuration.CrossoverType);

            var fitness = _fitnessFactory.Create(configuration);

            var geneticAlgorithm = new GeneticAlgorithm(
                population,
                fitness,
                selection,
                crossover,
                mutation);

            geneticAlgorithm.Termination = new FitnessStagnationTermination(configuration.Termination);
            geneticAlgorithm.TaskExecutor = new MultithreadTaskExecutor();
            return geneticAlgorithm;
        }

        private static ISelection GetSelection(SelectionType type)
        {
            return type switch
            {
                SelectionType.Elite => new EliteSelection(),
                SelectionType.RouletteWheel => new RouletteWheelSelection(),
                SelectionType.StochasticUniversalSampling => new StochasticUniversalSamplingSelection(),
                SelectionType.Tournament => new TournamentSelection(),
                SelectionType.Truncation => new TruncationSelection(),
                _ => throw new ArgumentException("Invalid selection type."),
            };
        }

        private static IMutation GetMutation(MutationType type)
        {
            return type switch
            {
                MutationType.Displacement => new DisplacementMutation(),
                MutationType.FlipBit => new FlipBitMutation(),
                MutationType.Insertion => new InsertionMutation(),
                MutationType.PartialShuffle => new PartialShuffleMutation(),
                MutationType.ReverseSequence => new ReverseSequenceMutation(),
                MutationType.Twors => new TworsMutation(),
                MutationType.Uniform => new UniformMutation(),
                _ => throw new ArgumentException("Invalid mutation type."),
            };
        }

        private static ICrossover GetCrossover(CrossoverType type)
        {
            return type switch
            {
                CrossoverType.AlternatingPosition => new AlternatingPositionCrossover(),
                CrossoverType.CutAndSplice => new CutAndSpliceCrossover(),
                CrossoverType.Cycle => new CycleCrossover(),
                CrossoverType.OnePoint => new OnePointCrossover(),
                CrossoverType.OrderBased => new OrderBasedCrossover(),
                CrossoverType.Ordered => new OrderedCrossover(),
                CrossoverType.PartiallyMapped => new PartiallyMappedCrossover(),
                CrossoverType.PositionBased => new PositionBasedCrossover(),
                CrossoverType.ThreeParent => new ThreeParentCrossover(),
                CrossoverType.TwoPoint => new TwoPointCrossover(),
                CrossoverType.Uniform => new UniformCrossover(0.9f),
                CrossoverType.VotingRecombination => new VotingRecombinationCrossover(),
                _ => throw new ArgumentException("Invalid crossover type."),
            };
        }
    }
}
