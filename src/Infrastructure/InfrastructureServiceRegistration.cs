using Ecommerce.Application.Models.Token;
using Ecommerce.Application.Persistence;
using Ecommerce.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration){
        services.AddScoped<UInitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
    
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


        return services;
    }
}