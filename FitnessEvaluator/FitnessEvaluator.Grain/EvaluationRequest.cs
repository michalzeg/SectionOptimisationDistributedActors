namespace FitnessEvaluator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct EvaluationRequest
    {
        public required double BottomFlangeWidth { get; init; }
        public required double BottomFlangeThickness { get; init; }
        public required double WebHeight { get; init; }
        public required double WebThickness { get; init; }
        public required double TopFlangeWidth { get; init; }
        public required double TopFlangeThickness { get; init; }
        public required double AllowedStress { get; init; }
        public required double MaxStress { get; init; }
        public required double TotalWeight { get; init; }
        public required double BeamLength { get; init; }
    }
}
