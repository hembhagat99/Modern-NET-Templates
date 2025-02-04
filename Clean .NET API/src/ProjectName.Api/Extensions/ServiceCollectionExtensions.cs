using FluentValidation;
using ProjectName.Api.Mapper;
using ProjectName.Api.StartupFilters;
using ProjectName.Api.Validators.Password;
using ProjectName.Infrastructure.Extensions;
using ProjectName.Infrastructure.Mapper;

namespace ProjectName.Api.Extensions
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
