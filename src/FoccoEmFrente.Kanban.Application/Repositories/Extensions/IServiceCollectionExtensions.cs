using Microsoft.Extensions.DependencyInjection;

namespace FoccoEmFrente.Kanban.Application.Repositories.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IPostitRepository, PostitRepository>();
        }
    }
}