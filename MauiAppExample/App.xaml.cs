using System.Diagnostics;
using MauiAppExample.Services;
using MauiAppExample.View;

namespace MauiAppExample;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        MainPage = serviceProvider.GetService<LoadingPage>();

        LoadInitialPage(serviceProvider);

    }

    public async void LoadInitialPage(IServiceProvider serviceProvider)
    {
        MainPage = new AppShell();

        var authService = serviceProvider.GetService<IAuthenticationService>();
        await authService.InitAsync();

        if (authService.IsAuthenticated)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            return;
        }

        await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");;
    }
}