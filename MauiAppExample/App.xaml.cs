using MauiAppExample.Services;
using MauiAppExample.View;

namespace MauiAppExample;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var authService = serviceProvider.GetService<IAuthenticationService>();

        if (authService.IsAuthenticated)
            MainPage = new AppShell();

        MainPage = serviceProvider.GetService<LoginPage>();
    }
}