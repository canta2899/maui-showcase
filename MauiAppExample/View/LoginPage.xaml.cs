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
    }
}
