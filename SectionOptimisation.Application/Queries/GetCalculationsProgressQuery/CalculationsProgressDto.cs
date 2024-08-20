namespace SectionOptimisation.Application.Queries.GetCalculationsProgressQuery
{
    public record struct CalculationsProgressDto
    {
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
        public required DateTimeOffset OccurredAt { get; init; }
    }
}
