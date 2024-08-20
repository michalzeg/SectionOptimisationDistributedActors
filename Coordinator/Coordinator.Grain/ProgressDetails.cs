namespace Coordinator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct ProgressDetails
    {
        public ProgressDetails()
        {
        }
        public required double BottomFlangeWidth { get; init; }
        public required double BottomFlangeThickness { get; init; }
        public required double WebHeight { get; init; }
        public required double WebThickness { get; init; }
        public required double TopFlangeWidth { get; init; }
        public required double TopFlangeThickness { get; init; }
        public required double TotalWeight { get; init; }
        public required double MaxStress { get; init; }
        public required bool Finished { get; init; }
        public required int ChromosomesEvaluated { get; init; }
        public DateTimeOffset OccurredAt { get; init; } = DateTimeOffset.UtcNow;
    }
}
