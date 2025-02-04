using Serilog;

namespace ProjectName.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void RegisterSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            builder.Services.AddSerilog();
        }
    }
}
