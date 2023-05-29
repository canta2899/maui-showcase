using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Data.Implementations;
using MauiAppExample.Extensions;
using MauiAppExample.Services.Abstractions;
using MauiAppExample.Services.Handlers;
using MauiAppExample.Services.Implementations;
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
                fonts.AddFont("MaterialIcons-Regular.ttf", "Material");
            });


        builder.Services.AddPages();
        builder.Services.AddClients();
        builder.Services.AddPlatformImplementations();

        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddTransient<IPostsRepository, PostsRepository>();
        builder.Services.AddTransient<IAuthRepository, AuthRepository>();
        builder.Services.AddTransient<IUIService, UIService>();

        #if DEBUG
        builder.Logging.AddDebug();
        #endif

        return builder.Build();
    }

    public static void AddPlatformImplementations(this IServiceCollection services)
    {
        // this allows test project to work

        #if (IOS || ANDROID || WINDOWS)
        services.AddTransient<IPlatformInfo, Platforms.PlatformInfo>();
        #endif
    }

    public static void AddPages(this IServiceCollection services)
    { 
        services.AddSingleton<LoadingPage>();
        services.AddSingleton<MainPage>();
        services.AddSingleton<InsertPage>();
        services.AddTransient<LoginPage>();
        services.AddTransient<DetailPage>();

        services.AddSingleton<MainPageViewModel>();
        services.AddSingleton<InsertPageViewModel>();
        services.AddTransient<LoginPageViewModel>();
        services.AddTransient<DetailPageViewModel>();
    }


    public static void AddClients(this IServiceCollection services)
    { 
        services.AddScoped<StrapiClientAuthHandler>();
        services.AddHttpClient("auth", client => 
        {
            client.AcceptOnlyJson();
            client.BaseAddress = new Uri(Shared.ApiAuthUrl);
        });

        services.AddHttpClient("services", client =>
        {
            client.AcceptOnlyJson();
            client.BaseAddress = new Uri(Shared.ApiServiceUrl);
        }).AddHttpMessageHandler<StrapiClientAuthHandler>();
    }
}