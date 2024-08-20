using GeneticSolver.Domain.Genetic;

namespace GeneticSolver.Domain.Ports
{
    public readonly record struct FemCalculationInput
    {
        public required BeamGeometry BeamGeometry { get; init; }
        public required double ExternalLoad { get; init; }
        public required double Weight { get; init; }
        public required double ModulusOfElasticity { get; init; }
        public required int Spans { get; init; }
        public required int BeamLength { get; init; }
    }
}
