using GeneticSolver.Shared.Types;

namespace GeneticSolver.Domain.Ports
{
    public readonly record struct GeneticSolverConfiguration
    {
        public required int Spans { get; init; }
        public required int BeamLength { get; init; }
        public required int AllowedStress { get; init; }
        public required int ModulusOfElasticity { get; init; }
        public required int Weight { get; init; }
        public required int ExternalLoad { get; init; }
        public required int MinPopulation { get; init; }
        public required int MaxPopulation { get; init; }
        public required int Termination { get; init; }
        public required MutationType MutationType { get; init; }
        public required SelectionType SelectionType { get; init; }
        public required CrossoverType CrossoverType { get; init; }
    }
}
