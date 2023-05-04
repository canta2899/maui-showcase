using System;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppExample.Data;
using MauiAppExample.Services;

namespace MauiAppExample.ViewModel;

public class LoginPageViewModel
{
    private IAuthenticationService _authService;

    public Command AuthenticateCommand { get; }

    public LoginPageViewModel(IAuthenticationService authService)
    {
        _authService = authService;
        AuthenticateCommand = new Command(Authenticate);;
    }

    private void Authenticate()
    {
        var status = _authService.Login("username", "password");
        WeakReferenceMessenger.Default.Send(status);
    }

}

