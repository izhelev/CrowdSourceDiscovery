namespace CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories
{
    public class RepositoryBase
    {
        protected CSDiscoveryContext Context;

        public RepositoryBase()
        {
            Context = new CSDiscoveryContext();
        }
    }
}