using GeoLocationDemoAPI.WebAPI.Extensions;
using GeoLocationDemoAPI.WebAPI.Middlewares;

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
            services.AddTransient<GeneralErrorHandling>();
        }

        public static void UseWebAPISetup(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSwaggerSetup();
            app.UseHttpsRedirection();
            app.UseMiddleware<GeneralErrorHandling>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
