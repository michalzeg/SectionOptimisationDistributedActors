using GeneticSolver.Domain.Genetic;

namespace GeneticSolver.Domain.Ports
{
    public record struct SolverProgress
    {
        public required BeamGeometry BeamGeometry { get; init; }
        public required double TotalWeight { get; init; }
        public required double MaxStress { get; init; }
        public required bool Finished { get; init; }
    }
}
