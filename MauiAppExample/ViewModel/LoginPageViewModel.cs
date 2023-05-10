using System;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppExample.Data;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services;

namespace MauiAppExample.ViewModel;

public class LoginPageViewModel : BaseViewModel
{
    private readonly StrapiClient _client;
    private string _identifier;
    private string _password;

    public string Identifier
    {
        get => _identifier;
        set => SetProperty(ref _identifier, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public Command AuthenticateCommand { get; }

    public LoginPageViewModel(StrapiClient client)
    {
        _client = client;
        Identifier = "";
        Password = "";
        AuthenticateCommand = new Command(
		    async () => await Authenticate());
    }

    private async Task Authenticate()
    {
        var response = await _client.Login(new AuthenticationRequest { Identifier = Identifier, Password = Password }); ;

        WeakReferenceMessenger.Default.Send(response);
    }

}

