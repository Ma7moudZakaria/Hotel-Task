using HotelInfrastructure.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelEntities.Entities;
using HotelDomain.Repositories;
using HotelInfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelInfrastructure;

public static class InfrastructureDIContainer
{
    public static IServiceCollection AddInfrastructureDIContainer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddMediatR(typeof(IMarkupAssemblyScanning));

        services.AddDbContext<HotelDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("HotelTest"));
        });

        return services;
    }
}