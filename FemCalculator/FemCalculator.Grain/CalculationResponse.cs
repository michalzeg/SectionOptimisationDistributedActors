namespace FemCalculator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct CalculationResponse
    {
        public required double TotalWeight { get; init; }
        public required double MaxStress { get; init; }
    }
}