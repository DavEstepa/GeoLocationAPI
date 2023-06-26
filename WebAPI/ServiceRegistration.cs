using GeoLocationDemoAPI.WebAPI.Extensions;

namespace GeoLocationDemoAPI.WebAPI
{
    public static class ServiceRegistration
    {
        public static void RegisterWebAPIServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSwaggerConfiguration();
            services.AddControllers();
        }

        public static void UseWebAPISetup(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSwaggerSetup();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
