namespace Infrastructure.Shared.Utils
{
    public class GrainIdentity : IGrainIdentity
    {
        private Guid _id;

        public Guid GetId() => _id;

        public void SetId(Guid id) => _id = id;
    }
}
