using System.Collections.ObjectModel;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Model;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.ViewModel;

public class MainPageViewModel : BaseViewModel 
{

    private readonly IPostsRepository _postsRepository;
    private readonly IAuthRepository _authRepository;
    private readonly IAuthenticationService _authService;
    private readonly IUIService _ui;
    private bool _isRefreshing;

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    public bool HasNoPosts => !Posts.Any();

    public string WelcomeMessage => $"Welcome, {_authService.CurrentUser.Username ?? "User"}";

    public ObservableCollection<Post> Posts { get; set; } = new();

    public Command LogoutCommand { get; }
    public Command LoadPostsCommand { get; }
    public Command NewPostCommand { get; }
    public Command ToDetailsCommand { get; }


    public MainPageViewModel(
        IAuthenticationService authService,
        IUIService ui,
        IPostsRepository p,
        IAuthRepository authRepository)
    {
        _ui = ui;
        _authService = authService;
        _postsRepository = p;
        _authRepository = authRepository;

        LoadPostsCommand = new Command(ToAsync(LoadPostsAsync));
        LogoutCommand = new Command(ToAsync(LogoutAsync));
        NewPostCommand = new Command(ToAsync(NewPostAsync));
        ToDetailsCommand = new Command(ToAsync(GoToDetailsAsync));
    }


    public async Task GoToDetailsAsync(object param)
    {
        if (param is not Post) return;

        var post = (Post)param;

        var pageParameters = new Dictionary<string, object>
        {
            { "CurrentPost", post },
        };

        await _ui.NavigateToAsync("DetailPage", pageParameters);
    }


    public async Task LogoutAsync(object param)
    {
        _authRepository.Logout();
        await _ui.NavigateToAsync("///LoginPage");
    }


    public async Task NewPostAsync(object param)
    {
        await _ui.NavigateToAsync("InsertPage");
    }


    public async Task LoadPostsAsync(object parm)
    {
        var currentPosts = await _postsRepository.GetAllAsync();

        Posts.Clear();

        foreach (var p in currentPosts) Posts.Add(p);

        OnPropertyChanged(nameof(HasNoPosts));
        IsRefreshing = false;
    }

}
