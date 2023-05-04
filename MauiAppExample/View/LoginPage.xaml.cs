using CommunityToolkit.Mvvm.Messaging;
using MauiAppExample.Data;
using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
        WeakReferenceMessenger.Default.Register<Response>(this, AuthenticationHandler);
    }

    private async void AuthenticationHandler(object sender, Response response)
    {
        if (response is ErrorResponse r)
        {
            await DisplayAlert("Warning", $"Invalid authentication: {r.ErrorMessage}", "Ok");
            return;
		}

        Application.Current.MainPage = new AppShell();
    }
}
