using Microsoft.Extensions.DependencyInjection;
namespace GrindChat.API.Data

{
    public static class ServiceExtensions
    {
        public static void AddFreeSql(this IServiceCollection services)
        {
            services.AddSingleton(FreesqlManager.HsjFreeSQL);
        }
    }
}
