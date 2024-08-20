namespace GeneticSolver.Domain.Ports
{
    public record EvaluationResult
    {
        public required double Factor { get; init; }
    }
}
