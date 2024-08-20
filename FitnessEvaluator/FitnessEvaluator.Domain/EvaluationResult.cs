namespace FitnessEvaluator.Domain
{
    public record struct EvaluationResult
    {
        public static EvaluationResult Failed => new() { Factor = double.MinValue };

        public required double Factor { get; init; }
    }
}
