using HotelDomain.Repositories;
using HotelEntities.Entities;
using HotelInfrastructure.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure.Repositories;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(HotelDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsReservationExistAsync(Guid roomId, DateTime reservationDate, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Reservation>()
                               .Where(a => a.RoomId.Equals(roomId))
                               .Where(a => a.ReservationDate == reservationDate)
                               .AnyAsync(cancellationToken);
    }
}