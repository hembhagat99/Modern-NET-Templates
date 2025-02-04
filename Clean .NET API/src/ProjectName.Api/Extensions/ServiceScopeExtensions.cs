namespace ProjectName.Api.Extensions
{
    internal static class ServiceScopeExtensions
    {
        public static T GetRequiredService<T>(this IServiceScope serviceScope)
            where T : notnull
        {
            return serviceScope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
