using AutoMapper;
using HotelDomain.Features.CQRS.Commands;
using HotelDomain.Features.DTO.Commands;
using HotelDomain.Repositories;
using HotelEntities.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HotelInfrastructure.Features.CQRS.Commands;

public class RoomCommandHandler : IRequestHandler<RoomCommand, int>
{
    private readonly ILogger _logger;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomCommandHandler(ILogger<RoomCommandHandler> logger,
                                  IRoomRepository roomRepository,
                                  IMapper mapper)
    {
        _logger = logger;
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(RoomCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start to check if the room is exist in the database");

        bool isRoomNumberExist = await _roomRepository.IsRoomExistAsync(request.RoomRequest.Id, cancellationToken);

        _logger.LogInformation($"Finished to check if the room is exist in the database");

        if (isRoomNumberExist)
            throw new Exception("Room number is exist in the database");

        // it's better to use manual mapper (performance)

        //Room Mapping()
        //{
        //    return new Room
        //    {
        //        Id = Guid.NewGuid(),
        //        Floor = request.RoomRequest.Floor,
        //        NumberOfBeds = request.RoomRequest.NumberOfBeds,
        //        RoomNumber = request.RoomRequest.RoomNumber,
        //        PricePerNight = request.RoomRequest.PricePerNight,
        //        RoomType = request.RoomRequest.RoomType
        //    };
        //}

        var mappedData = _mapper.Map<RoomDTO, Room>(request.RoomRequest);

        _logger.LogInformation($"Start to create the database");

        //int rows = await _reservationRepository.AddAsync(Mapping(), cancellationToken);
        int rows = await _roomRepository.AddAsync(mappedData, cancellationToken);

        _logger.LogInformation($"Finished to create the database");

        if (rows == 0)
            throw new Exception("Did not save the room data in the database");

        return rows;
    }
}