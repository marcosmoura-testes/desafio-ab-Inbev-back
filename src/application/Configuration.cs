using application.Interfaces;
using application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace application;

public static class Configuration
{
    public static IServiceCollection AddApplicationDataSetup(this IServiceCollection services)
    {
        services.AddScoped<IConsultEmployeeUseCase, ConsultEmployeeUseCase>();
        services.AddScoped<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
        services.AddScoped<IDeleteEmployeeUseCase, DeleteEmployeeUseCase>();
        services.AddScoped<IQueryEmployeeUseCase, QueryEmployeeUseCase>();
        services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();
        return services;
    }
}