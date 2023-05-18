using AutoMapper;
using HotelDomain.Features.CQRS.Commands;
using HotelDomain.Features.DTO.Commands;
using HotelDomain.Repositories;
using HotelEntities.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HotelInfrastructure.Features.CQRS.Commands;

public class ReservationCommandHandler : IRequestHandler<ReservationCommand, int>
{
    private readonly ILogger _logger;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationCommandHandler(ILogger<ReservationCommandHandler> logger,
                                  IReservationRepository reservationRepository,
                                  IMapper mapper)
    {
        _logger = logger;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(ReservationCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start to check if the reservation is exist in the database");

        bool isReservationExist = await _reservationRepository.IsReservationExistAsync(request.ReservationRequest.RoomId, request.ReservationRequest.ReservationDate, cancellationToken);

        _logger.LogInformation($"Finished to check if the reservation is exist in the database");

        if (isReservationExist)
            throw new Exception("Reservation is exist in the database");

        // it's better to use manual mapper (performance)

        //Reservation Mapping()
        //{
        //    return new Reservation
        //    {
        //        Id = Guid.NewGuid(),
        //        CustomerName = request.ReservationRequest.CustomerName,
        //        ReservationDate = request.ReservationRequest.ReservationDate,
        //        NumberOfNights = request.ReservationRequest.NumberOfNights,
        //        TotalPrice = request.ReservationRequest.TotalPrice,
        //        RoomId = request.ReservationRequest.RoomId
        //    };
        //}

        var mappedData = _mapper.Map<ReservationDTO, Reservation>(request.ReservationRequest);

        _logger.LogInformation($"Start to create the database");

        //int rows = await _reservationRepository.AddAsync(Mapping(), cancellationToken);
        int rows = await _reservationRepository.AddAsync(mappedData, cancellationToken);

        _logger.LogInformation($"Finished to create the database");

        if (rows == 0)
            throw new Exception("Did not save the reservation data in the database");

        return rows;
    }
}