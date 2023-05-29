using System;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Model;

namespace MauiAppExample.Tests.Mockups;

public class PostsRepositoryMockup : IPostsRepository 
{
    private IEnumerable<Post> _posts;
    public PostsRepositoryMockup(IEnumerable<Post> posts)
    {
        _posts = posts;
    }

    Task<IEnumerable<Post>> IPostsRepository.GetAllAsync()
    {
        return Task.Run(() =>
        {
            return _posts;
        });
    }

    public Task<Post> CreateAsync(Post p, Media m)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadMediaAsync(Post p)
    {
        throw new NotImplementedException();
    }
}

