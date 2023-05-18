using HotelDomain.Repositories.Shared;
using HotelEntities.Entities;

namespace HotelDomain.Repositories;

public interface IRoomRepository : IRepositoryBase<Room>
{
    Task<bool> IsRoomExistAsync(Guid id, CancellationToken cancellationToken);
}