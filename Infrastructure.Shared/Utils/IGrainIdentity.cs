namespace Infrastructure.Shared.Utils
{
    public interface IGrainIdentity
    {
        Guid GetId();
        void SetId(Guid id);
    }
}