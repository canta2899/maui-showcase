using MauiAppExample.Data;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Data.Implementations;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.ViewModel;

public class LoginPageViewModel : BaseViewModel
{
    private readonly IAuthRepository _authRepository;
    private readonly IUIService _ui;
    private string _identifier;
    private string _password;
    private string _platformInfo;

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

    public string PlatformInfo
    {
        get => _platformInfo;
        set => SetProperty(ref _platformInfo, value);
    }

    public Command AuthenticateCommand { get; }


    public LoginPageViewModel(IAuthRepository authRepository, IUIService ui)
    {
        _authRepository = authRepository;
        _ui = ui;
        Identifier = "";
        Password = "";
        PlatformInfo = ServiceProvider.GetService<IPlatformInfo>().GetPlatform();
        AuthenticateCommand = new Command(ToAsync(AuthenticateAsync));
    }


    public async Task AuthenticateAsync(object param)
    {
        try
        { 
            await _authRepository.LoginAsync(new AuthenticationRequest { Identifier = Identifier, Password = Password }); ;
            await _ui.NavigateToAsync($"///MainPage");
        }
        catch (Exception ex)
        { 
            await _ui.DisplayAlertAsync("Warning", $"Authentication error: {ex.Message}", "Ok");
        }
        finally
        {
            ClearEntries();
        }

    }


    public void ClearEntries()
    {
        Identifier = string.Empty;
        Password = string.Empty;
    }
}

