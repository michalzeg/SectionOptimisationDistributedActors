
namespace Coordinator.Grain
{
    [GenerateSerializer(GenerateFieldIds = GenerateFieldIds.PublicProperties)]
    public record struct ProgressResponse
    {
        public required IReadOnlyCollection<ProgressDetails> ProgressDetails { get; init; }
        public required DateTimeOffset StartedAt { get; init; }
    }
}
