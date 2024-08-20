using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Executors
{
    public class StatelessGrainExecutor : IStatelessGrainExecutor
    {
        private readonly IGrainFactory _grainFactory;
        private readonly FemGrainPool _grainPool = new();
        public StatelessGrainExecutor(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }

        public async ValueTask<TResult> ExecuteGrainMethod<TGrainInterface, TResult>(Func<TGrainInterface, ValueTask<TResult>> method) where TGrainInterface : IGrainWithGuidKey
        {
            var id = _grainPool.Rent();
            var grain = _grainFactory.GetGrain<TGrainInterface>(id);
            var result = await method.Invoke(grain);
            _grainPool.Return(id);
            return result;
        }
    }
}
