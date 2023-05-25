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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ClearEntries();
    }

    private void ClearEntries()
    { 
        userNameEntry.Text = "";
        passwordEntry.Text = "";
    }

    private async void AuthenticationHandler(object sender, Response response)
    {
        if (response is ErrorResponse r)
        {
            await DisplayAlert("Warning", $"Invalid authentication: {r.ErrorMessage}", "Ok");
            return;
        }

        ClearEntries();
        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
    }
}
