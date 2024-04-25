using Application.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddPersistance(configuration);

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var mySqlBuilder = new MySqlConnectionStringBuilder(
            configuration.GetConnectionString("LocalServer")!);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                mySqlBuilder.ConnectionString,
                ServerVersion.AutoDetect(mySqlBuilder.ConnectionString),
                options => options.EnableStringComparisonTranslations()));

        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<ITorneoRepository, TorneoRepository>();

        return services;
    }
}