using Coordinator.Grain;

namespace Coordinator.Silo.State
{
    [Serializable]
    public class CalculationsState
    {
        public List<ProgressDetails> Results { get; set; } = [];
        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;
        public required StartCalculationsRequest Input { get; init; }
    }
}
