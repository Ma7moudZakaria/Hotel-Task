using HotelDomain.Repositories;
using HotelEntities.Entities;
using HotelInfrastructure.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(HotelDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsRoomExistAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Room>()
                               .Where(a => a.Id == id)
                               .AnyAsync(cancellationToken);
    }
}