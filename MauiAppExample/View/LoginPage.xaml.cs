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
        await SecureStorage.Default.SetAsync("test", "value");

        var retrieved = await SecureStorage.Default.GetAsync("test");

        await DisplayAlert("Retrieved", $"The retrieved value is {retrieved}", "Ok");

        if (response is ErrorResponse r)
        {
            await DisplayAlert("Warning", $"Invalid authentication: {r.ErrorMessage}", "Ok");
            return;
        }

        Application.Current.MainPage = new AppShell();
    }
}
