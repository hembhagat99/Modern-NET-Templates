
using ProjectName.Api.Extensions;
using ProjectName.Domain.Repositories;

namespace ProjectName.Api.StartupFilters
{
    public class DatabaseMigrationStartupFilter(IHostEnvironment  hostEnvironment)
        : IStartupFilter
    {
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                if(_hostEnvironment.IsDevelopment())
                {
                    using (var serviceScope = builder.CreateServiceScope())
                    {
                        serviceScope!.GetRequiredService<IMigrationRepository>().ApplyPendingMigrations();
                    }

                    next(builder);
                }
            };
        }
    }
}
