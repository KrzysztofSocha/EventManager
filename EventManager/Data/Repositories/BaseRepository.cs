using EventManager.Data.Entities.EntityBase;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventManager.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public  IQueryable<T> GetAll()
        {            
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            HandleCreationAuditing(entity);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

      

        public async Task UpdateAsync(T entity)
        {
            var actual = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (actual == null)
                throw new Exception("Record with the specified ID was not found.");
            actual = entity;
            await _context.SaveChangesAsync();
        }
        #region HandleAuditing
        private void HandleCreationAuditing(T entity)
        {
            var entityType = typeof(T);
            var creationTimeProp = entityType.GetProperty("CreationTime");
            var creatorUserProp = entityType.GetProperty("CreatorUser");
            var creatorUserIdProp = entityType.GetProperty("CreatorUserId");
            if (creationTimeProp != null)
                creationTimeProp.SetValue(entity, DateTime.Now);
            if (creatorUserProp != null)
            {
                var currentUser = _httpContextAccessor.HttpContext.User;
                creatorUserProp.SetValue(entity, currentUser);
            }
            else if (creatorUserIdProp != null)
            {
                var currentUser = _httpContextAccessor.HttpContext.User;
                creatorUserIdProp.SetValue(entity, currentUser.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
        #endregion
    }
}
