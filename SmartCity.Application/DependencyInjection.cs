﻿using Microsoft.Extensions.DependencyInjection;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.Services;
using System.Reflection;

namespace SmartCity.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IPlaceService, PlaceService>();
        return services;
    }
}
