namespace Coordinator.Silo.State
{
    [Serializable]
    public class CoordinatorState
    {
        public Dictionary<Guid, CalculationsState> CalculationsState { get; set; } = [];
    }
}
