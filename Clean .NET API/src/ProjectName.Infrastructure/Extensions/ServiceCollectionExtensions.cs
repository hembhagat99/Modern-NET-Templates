using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Domain.Repositories;
using ProjectName.Infrastructure.Dbcontext;
using ProjectName.Infrastructure.Repositories;

namespace ProjectName.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProjectName");
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            serviceCollection.AddDbContext<ProjectNameDbContext>(options => options.UseMySql(connectionString, serverVersion));

            serviceCollection.AddScoped<IMigrationRepository, MigrationRepository>();
            serviceCollection.AddScoped<IDbTransactionProvider, DbTransactionProvider>();
            serviceCollection.AddScoped<ITodoRepository, TodoRepository>();
        }

        public static void RegisterIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ProjectNameDbContext>();
        }
    }
}
