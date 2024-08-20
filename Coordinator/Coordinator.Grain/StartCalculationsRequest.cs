namespace Coordinator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct StartCalculationsRequest
    {
        public required Guid CalculationId { get; init; }
        public required int Spans { get; init; }
        public required int BeamLength { get; init; }
        public required int MaxStress { get; init; }
        public required int ModulusOfElasticity { get; init; }
        public required int Weight { get; init; }
        public required int ExternalLoad { get; init; }
        public required int MinPopulation { get; init; }
        public required int MaxPopulation { get; init; }
        public required int Termination { get; init; }
        public required string? MutationType { get; init; }
        public required string? SelectionType { get; init; }
        public required string? CrossoverType { get; init; }
        public required string? Label { get; init; }
    }
}
