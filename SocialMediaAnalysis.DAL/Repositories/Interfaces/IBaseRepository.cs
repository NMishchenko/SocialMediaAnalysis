using System.Linq.Expressions;

namespace SocialMediaAnalysis.DAL.Repositories.Interfaces;

public interface IBaseRepository<TId, TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    Task DeleteByIdAsync(TId id);
    Task UpdateAsync(TEntity entity);
    Task<bool> CheckIfEntityExistsById(TId id);
    Task SaveChangesAsync();
}