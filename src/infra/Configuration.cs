using domain.UoW;
using infra.UoW;
using  Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace infra;

public static class Configuration
{
    public static IServiceCollection AddInfraDataSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStr = configuration["MySql:ConnectionString"];
        var connection = new MySqlConnection(connectionStr);

        services.AddDbContext<BaseContext>(options =>
            options.UseMySql(connection, 
                new MySqlServerVersion(new Version(8, 0, 32)), 
                mysqlOptions =>
                {
                    mysqlOptions.MigrationsAssembly("infra");
                    mysqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                })
        );


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}