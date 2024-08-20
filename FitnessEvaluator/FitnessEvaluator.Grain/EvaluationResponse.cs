namespace FitnessEvaluator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct EvaluationResponse
    {
        public required double Factor { get; init; }
    }
}
