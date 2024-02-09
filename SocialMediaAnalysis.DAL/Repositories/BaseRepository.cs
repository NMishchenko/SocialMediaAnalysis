using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SocialMediaAnalysis.DAL.Entities;
using SocialMediaAnalysis.DAL.Repositories.Interfaces;

namespace SocialMediaAnalysis.DAL.Repositories;

public abstract class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : BaseEntity<TId>
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(SocialMediaAnalysisContext socialMediaAnalysisContext)
    {
        _context = socialMediaAnalysisContext;
        _dbSet = _context.Set<TEntity>();
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async virtual Task DeleteByIdAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async virtual Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
    {
        var entities = _dbSet.Where(filter);
        return await entities.ToListAsync();
    }

    public async virtual Task<TEntity?> GetByIdAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async virtual Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckIfEntityExistsById(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity is not null;
    }

    public async virtual Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}