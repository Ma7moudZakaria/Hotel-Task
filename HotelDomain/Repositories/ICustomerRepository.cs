using HotelDomain.Repositories.Shared;
using HotelEntities.Entities;

namespace HotelDomain.Repositories;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken);
}
