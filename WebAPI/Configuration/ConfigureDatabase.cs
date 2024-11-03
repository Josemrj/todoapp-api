using Microsoft.Extensions.Options;

namespace WebAPI.Configuration
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
            services.AddSingleton(service => service.GetRequiredService<IOptions<DbSettings>>().Value);
            
            return services;
        }
    }
}
