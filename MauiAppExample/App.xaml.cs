using System.Diagnostics;
using MauiAppExample.Services;
using MauiAppExample.Services.Abstractions;
using MauiAppExample.View;

namespace MauiAppExample;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        ServiceProvider = serviceProvider;
        ShowLoadingPage();
        LoadInitialPage();
    }

    public void ShowLoadingPage()
    { 
        MainPage = ServiceProvider.GetService<LoadingPage>();
    }

    public async void LoadInitialPage()
    {
        MainPage = new AppShell();

        var authService = ServiceProvider.GetService<IAuthenticationService>();
        await authService.InitAsync();

        if (authService.IsAuthenticated)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            return;
        }

        await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");;
    }
}