using HotelDomain.Repositories;
using HotelEntities.Entities;
using HotelInfrastructure.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(HotelDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken)
    {
        if (!_dbContext.Database.CanConnect())
        {
            var res = await _dbContext.Database.EnsureCreatedAsync();
        }

        return await _dbContext.Set<Customer>().AnyAsync(a => a.Email.Equals(email), cancellationToken);
    }
}