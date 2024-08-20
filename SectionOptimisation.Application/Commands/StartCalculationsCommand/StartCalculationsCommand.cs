using MediatR;

namespace SectionOptimisation.Application.Commands.StartCalculationsCommand
{
    public record StartCalculationsCommand : IRequest
    {
        public required int Spans { get; init; }
        public required int Length { get; init; }
        public required int MaxStress { get; init; }
        public required int ModulusOfElasticity { get; init; }
        public required int Weight { get; init; }
        public required int Load { get; init; }
        public required int[] Population { get; init; } = [];
        public required int Termination { get; init; }
        public required string? Mutation { get; init; }
        public required string Selection { get; init; } = string.Empty;
        public required string Crossover { get; init; } = string.Empty;
        public required string Label { get; init; } = string.Empty;
    }
}
