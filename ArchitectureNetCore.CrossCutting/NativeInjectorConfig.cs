using ArchitectureNetCore.Data.Dapper;
using ArchitectureNetCore.Data.EF;
using ArchitectureNetCore.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectureNetCore.CrossCutting
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITruckRepositoryEF, TruckRepositoryEF>();
            services.AddScoped<ITruckRepositoryDapper, TruckRepositoryDapper>();
        }
    }
}
