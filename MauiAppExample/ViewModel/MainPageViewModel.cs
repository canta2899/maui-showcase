using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppExample.Model;
using MauiAppExample.Services;
using MauiAppExample.View;

namespace MauiAppExample.ViewModel;

public class MainPageViewModel : BaseViewModel 
{

	private readonly PostsRepository _postsRepository;
	private readonly IAuthenticationService _authService;

	public Command NavigateCommand { get;  } 
	public Command OnAppearingCommand { get; }

	public ObservableCollection<Post> Posts { get; set; } = new();

	public string WelcomeMessage => $"Welcome {_authService.CurrentUser.Username ?? "User"}";

	public MainPageViewModel(IAuthenticationService authService, PostsRepository p)
	{
		_authService = authService;
		_postsRepository = p;

		NavigateCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync(nameof(InsertPage));
		});

		OnAppearingCommand = new Command(async () => await LoadPosts());
	}

	public async Task LoadPosts()
	{
		var currentPosts = await _postsRepository.GetForCurrentUser();
		Posts.Clear();

		foreach (var p in currentPosts) Posts.Add(p);
	}
}
