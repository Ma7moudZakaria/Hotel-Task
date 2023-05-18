using HotelDomain.Repositories.Shared;
using HotelEntities.Entities;

namespace HotelDomain.Repositories;

public interface IReservationRepository : IRepositoryBase<Reservation>
{
    Task<bool> IsReservationExistAsync(Guid roomId, DateTime reservationDate, CancellationToken cancellationToken);
}
