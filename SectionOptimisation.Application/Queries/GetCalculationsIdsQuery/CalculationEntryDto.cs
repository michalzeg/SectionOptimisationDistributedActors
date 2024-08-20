using MediatR;

namespace SectionOptimisation.Application.Commands.StartCalculationsCommand
{
    public record CalculationEntryDto
    {
        public required int Spans { get; init; }
        public required int Length { get; init; }
        public required int MaxStress { get; init; }
        public required int ModulusOfElasticity { get; init; }
        public required int Weight { get; init; }
        public required int Load { get; init; }
        public required int[]? Population { get; init; }
        public required int Termination { get; init; }
        public required string? Mutation { get; init; }
        public required string? Selection { get; init; }
        public required string? Crossover { get; init; }
        public required string? Label { get; init; }
        public required Guid CalculationId { get; init; }
    }
}
