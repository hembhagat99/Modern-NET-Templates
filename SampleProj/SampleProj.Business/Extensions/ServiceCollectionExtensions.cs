using Microsoft.Extensions.DependencyInjection;
using SampleProj.Business.Services;
using SampleProj.Business.Services.Impl;

namespace SampleProj.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITodoService, TodoService>();
        }
    }
}
