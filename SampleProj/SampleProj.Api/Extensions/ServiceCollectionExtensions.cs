using FluentValidation;
using SampleProj.Api.Mapper;
using SampleProj.Api.StartupFilters;
using SampleProj.Api.Validators.Password;
using SampleProj.Infrastructure.Extensions;
using SampleProj.Infrastructure.Mapper;

namespace SampleProj.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void RegisterAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization();
            serviceCollection.RegisterIdentity();
        }

        public static void RegisterValidtors(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddValidatorsFromAssemblyContaining<TodoDtoValidator>();
        }

        public static void RegisterAutomapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(TodoMapperProfile), typeof(TodoDataModelMapperProfile));
        }

        public static void RegisterStartupFilters(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStartupFilter, DatabaseMigrationStartupFilter>();
        }
    }
}
