namespace SectionOptimisation.Application.Commands.StartCalculationsCommand
{
    public record StartCalculationsExtendedCommand : StartCalculationsCommand
    {
        public required Guid CalculationId { get; init; }
    }
}
