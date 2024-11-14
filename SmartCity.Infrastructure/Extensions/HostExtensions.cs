using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartCity.Infrastructure.DataSeeding;

namespace SmartCity.Infrastructure.Extensions;

public static class HostExtensions {
    public static async Task SeedDatabaseAsync(this IHost host) {
        using var scope = host.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<AppDbSeeder>();
        await seeder.SeedAsync().ConfigureAwait(false);
    }
}
