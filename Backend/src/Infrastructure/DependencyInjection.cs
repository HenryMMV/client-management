using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING")
            ?? "User Id=hr;Password=hr;Data Source=localhost/XEPDB1";

        services.AddDbContext<ClientDbContext>(options =>
            options.UseOracle(connectionString));

        services.AddScoped<IClienteReadService, ClienteReadService>();

        return services;
    }
}
