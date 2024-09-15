using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Infrastructure.DataContext;
using SmartCity.Infrastructure.Repositories;
using SmartCity.Infrastructure.Repositories.GisOsm;
using System.Data;

namespace SmartCity.Infrastructure;

public static class DependencyInjection {
    private const string SMART_CITY_CONTEXT_KEY = "SmartCityContext";
    private const string GIS_OSM_CONTEXT_KEY = "GisOsmContext";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
        services.AddDatabase();
        services.AddServices();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services) {
        // Configure EF Core DbContext
        services.AddDbContext<SmartCityContext>((serviceProvider, options) => {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            options.UseNpgsql(configuration.GetConnectionString(SMART_CITY_CONTEXT_KEY));
        });

        // Configure Dapper IDbConnection
        services.AddScoped<IDbConnection>(serviceProvider => {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(GIS_OSM_CONTEXT_KEY);
            return new NpgsqlConnection(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IGisOsmPoiRepository, GisOsmPoiRepository>();
        services.AddScoped<IPoiDetailRepository, PoiDetailsRepository>();
        services.AddScoped<IPoiPhotoRepository, PoiPhotoRepository>();
        services.AddScoped<IPoiReviewRepository, PoiReviewRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
