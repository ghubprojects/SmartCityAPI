﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SmartCity.Application.Abstractions.Providers;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Infrastructure.Configurations;
using SmartCity.Infrastructure.DataContext;
using SmartCity.Infrastructure.DataSeeding;
using SmartCity.Infrastructure.Providers;
using SmartCity.Infrastructure.Repositories;
using SmartCity.Infrastructure.Repositories.GisOsm;

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
        services.AddDbContext<AppDbContext>((sp, options) => {
            options.UseNpgsql(sp.GetRequiredService<IConfiguration>().GetConnectionString(SMART_CITY_CONTEXT_KEY));
        });
        services.AddScoped<AppDbSeeder>();

        // Configure MongoDb client and context
        services.AddSingleton<IMongoClient>(sp =>
            new MongoClient(sp.GetRequiredService<IConfiguration>().GetConnectionString(GIS_OSM_CONTEXT_KEY)));
        services.AddScoped<GisOsmContext>();

        // Configure Jwt
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IPoiRepository, PoiRepository>();
        services.AddScoped<IGadmRepository, GadmRepository>();
        services.AddScoped<IPlaceDetailRepository, PlaceDetailRepository>();
        services.AddScoped<IPlaceTypeRepository, PlaceTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }
}
