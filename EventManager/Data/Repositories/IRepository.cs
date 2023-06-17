using EventManager.Data.Entities.EntityBase;

namespace EventManager.Data.Repositories
{
    public interface IRepository
    {
        void InsertAsync(IEntity entity);
        IEntity GetByIdAsync(int id);

    }
}
