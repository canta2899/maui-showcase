using MauiAppExample.Model;

namespace MauiAppExample.Tests;

public class ExampleTest
{
    [Fact]
    public async void mainpage_loads_posts()
    {
        var posts = new List<Post>
        {
            new() { Title = "titolo1", FullText = "testo1" },
            new() { Title = "titolo2", FullText = "testo2" },
            new() { Title = "titolo3", FullText = "testo3" }
        };

        var repository = new Mockups.PostsRepositoryMockup(posts);
        var uiService = new Mockups.UIServiceMockup();
        var authRepository = new Mockups.AuthRepositoryMockup();
        var authService = new Mockups.AuthenticationServiceMockup();

        var mainPageViewModel = new MauiAppExample.ViewModel.MainPageViewModel(authService, uiService, repository, authRepository);

        await mainPageViewModel.LoadPostsAsync(null);

        Assert.NotEmpty(mainPageViewModel.Posts);
        Assert.Distinct(mainPageViewModel.Posts);
        Assert.Collection(mainPageViewModel.Posts,
             item1 => Assert.Equal("titolo1", item1.Title),
             item2 => Assert.Equal("titolo2", item2.Title),
             item3 => Assert.Equal("titolo3", item3.Title)); 
    }

    [Fact]
    public void title_normalization()
    {
        Assert.Equal("my-file.pdf", ViewModel.DetailPageViewModel.NormalizeTitle("My file.pdf"));
        Assert.Equal("my_file.pdf", ViewModel.DetailPageViewModel.NormalizeTitle("My_File.pdf"));
    }
}
