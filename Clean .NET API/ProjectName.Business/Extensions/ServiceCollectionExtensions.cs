using Microsoft.Extensions.DependencyInjection;
using ProjectName.Business.Services;
using ProjectName.Business.Services.Impl;

namespace ProjectName.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITodoService, TodoService>();
        }
    }
}
