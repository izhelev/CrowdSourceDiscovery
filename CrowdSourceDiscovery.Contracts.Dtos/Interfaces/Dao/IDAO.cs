namespace CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao
{
    public interface IDAO<T>
    {
        int Insert(T dto);
        void Update(T dto);
        void Delete(T dto);
        T Select(int id);
    }
}