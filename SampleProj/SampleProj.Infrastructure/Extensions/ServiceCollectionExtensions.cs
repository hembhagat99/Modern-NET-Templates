using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleProj.Domain.Repositories;
using SampleProj.Infrastructure.Dbcontext;
using SampleProj.Infrastructure.Repositories;

namespace SampleProj.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SampleProj");
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            serviceCollection.AddDbContext<SampleProjDbContext>(options => options.UseMySql(connectionString, serverVersion));

            serviceCollection.AddScoped<IMigrationRepository, MigrationRepository>();
            serviceCollection.AddScoped<IDbTransactionProvider, DbTransactionProvider>();
            serviceCollection.AddScoped<ITodoRepository, TodoRepository>();
        }

        public static void RegisterIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<SampleProjDbContext>();
        }
    }
}
