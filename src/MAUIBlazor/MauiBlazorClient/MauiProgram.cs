using MauiBlazorClient.Authorization;
using MauiBlazorClient.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using RazorClassLibrary.Extensions;
using System.Security.Claims;
using static MauiBlazorClient.Authorization.CustomAuthenticationStateProvider;

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
            // dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Authentication

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddSingleton<AuthenticatedUser>();
            var host = builder.Build();

            var authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();

            var user = new ClaimsPrincipal(new ClaimsIdentity());

            authenticatedUser.Principal = user;

            return host;
        }
    }
}