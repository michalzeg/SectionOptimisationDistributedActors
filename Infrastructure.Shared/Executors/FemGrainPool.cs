using System.Collections.Concurrent;

namespace Infrastructure.Shared.Executors
{
    internal sealed class FemGrainPool
    {
        private readonly ConcurrentQueue<Guid> _pool = new();

        public Guid Rent()
        {
            if (_pool.TryDequeue(out var item))
            {
                return item;
            }
            else
            {
                return Guid.NewGuid();
            }
        }

        public void Return(Guid item)
        {
            _pool.Enqueue(item);
        }
    }
}
