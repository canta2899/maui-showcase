using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppExample.Model;
using MauiAppExample.Services;
using MauiAppExample.View;
using Security;

namespace MauiAppExample.ViewModel;

public class MainPageViewModel : BaseViewModel 
{

	private readonly StrapiClient _client;
	private readonly IAuthenticationService _authService;

	public Command NavigateCommand { get;  } 

	public string WelcomeMessage => $"Welcome {_authService.CurrentUser.Username ?? "User"}";

	public MainPageViewModel(StrapiClient client, IAuthenticationService authService)
	{
		_client = client;
		_authService = authService;

		NavigateCommand = new Command(async () =>
		{
		 await Shell.Current.GoToAsync(nameof(ProductPage));
		});
	}
}