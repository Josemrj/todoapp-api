namespace WebAPI.Configuration
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services, WebApplicationBuilder builder) =>
            services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

           
        
    }
}
