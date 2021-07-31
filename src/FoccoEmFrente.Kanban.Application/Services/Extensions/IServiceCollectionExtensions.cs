using Microsoft.Extensions.DependencyInjection;

namespace FoccoEmFrente.Kanban.Application.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IPostitService, PostitService>();
        }
    }
}
