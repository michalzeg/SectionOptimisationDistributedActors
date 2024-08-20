
namespace Coordinator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct CalculationsListResponse
    {
        public required IReadOnlyCollection<StartCalculationsRequest> CalculationInputs { get; init; }
    }
}
