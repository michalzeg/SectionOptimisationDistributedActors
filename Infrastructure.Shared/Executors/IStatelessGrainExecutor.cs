namespace Infrastructure.Shared.Executors
{
    public interface IStatelessGrainExecutor
    {
        ValueTask<TResult> ExecuteGrainMethod<TGrainInterface, TResult>(Func<TGrainInterface, ValueTask<TResult>> method) where TGrainInterface : IGrainWithGuidKey;
    }
}
