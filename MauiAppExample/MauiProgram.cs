using CommunityToolkit.Maui;
using MauiAppExample.Extensions;
using MauiAppExample.Services;
using MauiAppExample.View;
using MauiAppExample.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiAppExample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<InsertPageViewModel>();
        builder.Services.AddSingleton<InsertPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddScoped<StrapiClientAuthHandler>();
        builder.Services.AddTransient<PostsRepository>();
        builder.Services.AddTransient<AuthRepository>();

        builder.Services.AddHttpClient("auth", client => 
        {
            client.AcceptOnlyJson();
            client.BaseAddress = new Uri(Shared.StrapiAuthUrl);
        });

        builder
            .Services
            .AddHttpClient("services", client =>
            {
                client.AcceptOnlyJson();
                client.BaseAddress = new Uri(Shared.StrapiServiceUrl);
            })
            .AddHttpMessageHandler<StrapiClientAuthHandler>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}