using GeneticSolver.Shared.Types;

namespace GeneticSolver.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct GeneticSolverExecutionRequest
    {
        public required int Spans { get; init; }
        public required int BeamLength { get; init; }
        public required int MaxStress { get; init; }
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
