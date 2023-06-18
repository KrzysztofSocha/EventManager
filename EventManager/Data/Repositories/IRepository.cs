using EventManager.Data.Entities.EntityBase;

namespace EventManager.Data.Repositories
{
    public interface IRepository<T> where T: IEntity
    {
        Task InsertAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllListAsync();
        Task UpdateAsync(T entity);
    }
}
