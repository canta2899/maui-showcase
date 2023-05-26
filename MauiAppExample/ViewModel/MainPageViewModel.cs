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
    private readonly AuthRepository _authRepository;
    private readonly IAuthenticationService _authService;
	private readonly IInteractionService _uiService;
	private bool _isRefreshing;


	public string WelcomeMessage => $"Welcome, {_authService.CurrentUser.Username ?? "User"}";

	public ObservableCollection<Post> Posts { get; set; } = new();

	public Command LogoutCommand { get; }
	public Command LoadPostsCommand { get; }
	public Command NewPostCommand { get; }
	public Command InspectCommand { get; }

	public bool IsRefreshing
	{
		get => _isRefreshing;
		set => SetProperty(ref _isRefreshing, value);
    }


	public MainPageViewModel(IAuthenticationService authService, IInteractionService uiService, PostsRepository p, AuthRepository authRepository)
	{
		_uiService = uiService;
		_authService = authService;
		_postsRepository = p;
        _authRepository = authRepository;

		LoadPostsCommand = new Command(async () => await LoadPosts());
		LogoutCommand = new Command(async () => await Logout());
		NewPostCommand = new Command(async () => await NewPost());
        InspectCommand = new Command(async (p) => await InspectAsync((Post)p));
	}

    private async Task InspectAsync(Post p)
    {
		await _uiService.DisplayAlert("Inspect", $"Inspecting post {p.Title}", "Ok");
    }

    private async Task Logout()
	{
		_authRepository.Logout();
		await _uiService.NavigateTo($"///{nameof(LoginPage)}");
    }

	private async Task NewPost()
	{
		await _uiService.NavigateTo(nameof(InsertPage));
    }

	private async Task LoadPosts()
	{
		var currentPosts = await _postsRepository.GetForCurrentUser();
		Posts.Clear();

		foreach (var p in currentPosts)
		{
			Posts.Add(p);
		}

		IsRefreshing = false;
	}
}
