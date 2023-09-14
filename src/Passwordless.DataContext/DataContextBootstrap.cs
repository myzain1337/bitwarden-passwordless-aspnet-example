using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Passwordless.DataContext;

public static class DataContextBootstrap
{
    public static void AddDataContext(this IServiceCollection services)
    {
        services.AddDbContext<PasswordlessContext>();
    }

    public static void MigrateDataContext(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PasswordlessContext>();
        dbContext.Database.Migrate();
    }
}