namespace FemCalculator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct CalculationRequest
    {
        public required double Weight { get; init; }
        public required double ExternalLoad { get; init; }
        public required IReadOnlyList<SpanDetails> Spans { get; init; }
    }
}