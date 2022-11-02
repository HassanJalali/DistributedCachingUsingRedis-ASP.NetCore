namespace Distributed_Caching.Services
{
    public interface IEmployeeRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
