namespace ProjectName.Api.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static IServiceScope? CreateServiceScope(this IApplicationBuilder builder)
        {
            return builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
        }
    }
}
