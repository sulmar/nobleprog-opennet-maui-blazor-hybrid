using MauiBlazorClient.Data;
using Microsoft.Extensions.Logging;
using RazorClassLibrary.Extensions;

namespace MauiBlazorClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddTracker();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            // Install-Package Microsoft.Extensions.Localization
            builder.Services.AddLocalization();

            builder.Services.AddAuthorizationCore();

            return builder.Build();
        }
    }
}