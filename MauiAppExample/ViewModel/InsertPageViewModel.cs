using MauiAppExample.Data.Abstractions;
using MauiAppExample.Model;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.ViewModel;

public class InsertPageViewModel : BaseViewModel 
{
    private readonly IUIService _ui;
    private readonly IPostsRepository _postsRepository;
    private string _currentTitle;
    private string _currentText;
    private FileResult _currentMedia;

    public string CurrentTitle
    {
        get => _currentTitle;
        set => SetProperty(ref _currentTitle, value);
    }

    public string CurrentText
    {
        get => _currentText;
        set => SetProperty(ref _currentText, value);
    }

    public FileResult CurrentFile
    {
        get => _currentMedia;
        set => SetProperty(ref _currentMedia, value);
    }

    public Command PickFileCommand { get; }
    public Command PublishCommand { get; }


    public InsertPageViewModel(IPostsRepository postsRepository, IUIService ui)
    {
        _postsRepository = postsRepository;
        _ui = ui;

        PickFileCommand = new Command(ToAsync(PickFileAsync));
        PublishCommand = new Command(ToAsync(PublishAsync));
    }


    public bool CanPublish()
    { 
         return !string.IsNullOrEmpty(CurrentTitle) &&
                !string.IsNullOrEmpty(CurrentText)  &&
                CurrentFile is not null;
    }


    public async Task PickFileAsync(object param)
    { 
        CurrentFile = await FilePicker.Default.PickAsync();
    }


   public async Task<Media> GetCurrentMediaAsync()
    {
        if (CurrentFile is null) return null;

        return new Media
        {
            ContentType = MimeTypes.GetMimeType(CurrentFile.FileName),
            Name = CurrentFile.FileName,
            Content = await CurrentFile.OpenReadAsync()
        };
    }


    public async Task PublishAsync(object param)
    {
        if (!CanPublish())
        {
            await _ui.DisplayAlertAsync("Warning", "Fill all the entries before publishing", "Ok");
            return;
        }

        var post = new Post
        {
            Title = CurrentTitle,
            FullText = CurrentText,
        };

        var media = await GetCurrentMediaAsync();

        await CreatePostAsync(post, media);
    }


    public async Task CreatePostAsync(Post post, Media media)
    { 
        try
        { 
            await _postsRepository.CreateAsync(post, media);
            ClearData();
            await _ui.NavigateToAsync("..");
        }
        catch(Exception ex)
        {
            await _ui.DisplayAlertAsync("Warning", $"An error occoured: {ex.Message}", "Ok");
        }
    }


    public void ClearData()
    {
        CurrentFile = null;
        CurrentTitle = string.Empty;
        CurrentText = string.Empty;
    }

}