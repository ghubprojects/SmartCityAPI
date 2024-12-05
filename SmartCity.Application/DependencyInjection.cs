using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.Services;
using System.Reflection;

namespace SmartCity.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IPlaceService, PlaceService>();
        services.AddScoped<IGeometryService, GeometryService>();
        return services;
    }
}
