using System;
using CommunityToolkit.Maui.Storage;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Model;
using MauiAppExample.Services;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.ViewModel;

[QueryProperty(nameof(CurrentPost), "CurrentPost")]
public class DetailPageViewModel : BaseViewModel
{
    private readonly IFileSaver _fileSaver;
    private readonly IUIService _ui;
    private readonly IPostsRepository _postsRepository;
    private Post _currentPost;

    public Post CurrentPost
    {
        get => _currentPost;
        set => SetProperty(ref _currentPost, value);
    }

    public Command DownloadCommand { get; set; }

    public DetailPageViewModel(IFileSaver fileSaver, IUIService ui, IPostsRepository postsRepository) 
    {
        _fileSaver = fileSaver;
        _ui = ui;
        _postsRepository = postsRepository;
        DownloadCommand = new Command(ToAsync(DownloadAsync));
    }

    public static string NormalizeTitle(string title)
    {
        return title.Replace(" ", "-").ToLower().Trim();
    }

    public async Task DownloadAsync(object param)
    {
        var title = NormalizeTitle(CurrentPost.Asset.Data.Attributes.Name);

        try
        { 
            var content = await _postsRepository.DownloadMediaAsync(CurrentPost);
            await _fileSaver.SaveAsync(title, content, CancellationToken.None);
        }
        catch (Exception)
        {
            await _ui.DisplayAlertAsync("Error", "Unable to download file to local device", "Ok");
        }
    }
}

