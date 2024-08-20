namespace GeneticSolver.Domain.Ports
{
    public record struct EvaluationProgress
    {
        public required int ChromosomesEvaluated { get; init; }
    }
}
