using FemCalculator.Domain.Models;

namespace FemCalculator.Domain
{
    public record struct FemCalculationInput
    {
        public required double Weight { get; init; }
        public required double ExternalLoad { get; init; }
        public required IReadOnlyList<BeamSpan> Spans { get; init; }
    }
}
