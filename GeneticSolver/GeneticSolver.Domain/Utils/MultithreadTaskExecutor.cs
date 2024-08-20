using GeneticSharp;

namespace GeneticSolver.Domain.Utils
{
    public class MultithreadTaskExecutor : ParallelTaskExecutor
    {
        private readonly int _maxLevelOfParallelism;

        public MultithreadTaskExecutor(int maxLevelOfParallelism = 32)
        {
            _maxLevelOfParallelism = maxLevelOfParallelism;
        }

        public override bool Start()
        {
            try
            {
                DateTime startTime = DateTime.Now;
                CancellationTokenSource = new CancellationTokenSource();
                ParallelLoopResult parallelLoopResult = default;
                try
                {
                    parallelLoopResult = Parallel.For(0, Tasks.Count, new ParallelOptions
                    {
                        CancellationToken = CancellationTokenSource.Token,
                        MaxDegreeOfParallelism = _maxLevelOfParallelism
                    }, (i, state) =>
                    {
                        Tasks[i]();
                        if (CancellationTokenSource.IsCancellationRequested || DateTime.Now - startTime > Timeout)
                        {
                            state.Break();
                        }
                    });
                }
                catch (OperationCanceledException)
                {
                }

                return parallelLoopResult.IsCompleted;
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}
