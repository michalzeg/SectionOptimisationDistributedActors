namespace GeneticSolver.Domain.Ports
{
    public record struct FemCalculationResult
    {
        public required double TotalWeight { get; init; }
        public required double MaxStress { get; init; }
    }
}
