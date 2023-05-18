using HotelEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories.Shared;

public abstract class RepositoryBase<T> where T : class
{
    protected readonly HotelDbContext _dbContext;

    protected RepositoryBase(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task<int> AddAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Add(entity);
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Update(entity);
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Remove(entity);
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}