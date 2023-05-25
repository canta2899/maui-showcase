using CommunityToolkit.Mvvm.Messaging;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services;

namespace MauiAppExample.ViewModel;

public class LoginPageViewModel : BaseViewModel
{
    private readonly AuthRepository _authRepository;
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

    public LoginPageViewModel(AuthRepository authRepository)
    {
        _authRepository = authRepository;
        Identifier = "";
        Password = "";
        AuthenticateCommand = new Command(
		    async () => await Authenticate());
    }

    private async Task Authenticate()
    {
        var response = await _authRepository.Login(new AuthenticationRequest { Identifier = Identifier, Password = Password }); ;

        WeakReferenceMessenger.Default.Send(response);
    }

}

