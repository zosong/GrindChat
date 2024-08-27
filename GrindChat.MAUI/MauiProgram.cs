using Microsoft.Extensions.DependencyInjection;
using GrindChat.Library.Services;
using Microsoft.Extensions.Logging;
using GrindChat.MAUI.Services;
using System;

namespace GrindChat.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri("https://localhost:7236/")
            });

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<TeamService>();
            builder.Services.AddScoped<UserTeamService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Use the app creation delegate with service provider
            builder.UseMauiApp(sp => new App(sp));

            return builder.Build();
        }
    }
}
