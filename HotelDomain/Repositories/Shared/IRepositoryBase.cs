namespace HotelDomain.Repositories.Shared;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<int> AddAsync(T entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
}