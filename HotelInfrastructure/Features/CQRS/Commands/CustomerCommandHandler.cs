using AutoMapper;
using HotelDomain.Features.CQRS.Commands;
using HotelDomain.Features.DTO.Commands;
using HotelDomain.Repositories;
using HotelEntities.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HotelInfrastructure.Features.CQRS.Commands;

public class CustomerCommandHandler : IRequestHandler<CustomerCommand, int>
{
    private readonly ILogger _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerCommandHandler(ILogger<CustomerCommandHandler> logger,
                                  ICustomerRepository customerRepository,
                                  IMapper mapper)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CustomerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start to check if the customer email is not null or emty");

        if (string.IsNullOrEmpty(request.CustomerRequest.Email))
            throw new Exception("customer email can not be null or emty");

        _logger.LogInformation($"Finished to check if the customer email is not null or emty");

        _logger.LogInformation($"Start to check if the customer is exist in the database");

        bool isEmailExist = await _customerRepository.IsEmailExistAsync(request.CustomerRequest.Email, cancellationToken);

        _logger.LogInformation($"Finished to check if the customer is exist in the database");

        if (isEmailExist)
            throw new Exception("customer email is exist in the database");

        // it's better to use manual mapper (performance)

        //Customer Mapping()
        //{
        //    return new Customer
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = request.CustomerRequest.Name,
        //        Address = request.CustomerRequest.Address,
        //        DateOfBirth = request.CustomerRequest.DateOfBirth,
        //        Email = request.CustomerRequest.Email,
        //        Phone = request.CustomerRequest.Phone
        //    };
        //}

        var mappedData = _mapper.Map<CustomerDTO, Customer>(request.CustomerRequest);

        _logger.LogInformation($"Start to create the database");

        //int rows = await _customerRepository.AddAsync(Mapping(), cancellationToken);
        int rows = await _customerRepository.AddAsync(mappedData, cancellationToken);

        _logger.LogInformation($"Finished to create the database");

        if(rows == 0)
            throw new Exception("Did not save the customer data in the database");

        return rows;
    }
}