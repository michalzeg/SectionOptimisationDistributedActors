namespace FemCalculator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct SpanDetails
    {
        public required double BottomFlangeWidth { get; init; }
        public required double BottomFlangeThickness { get; init; }
        public required double WebHeight { get; init; }
        public required double WebThickness { get; init; }
        public required double TopFlangeWidth { get; init; }
        public required double TopFlangeThickness { get; init; }
        public required double Length { get; init; }
        public required double ModulusOfElasticity { get; init; }
    }
}