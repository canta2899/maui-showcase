using System;
using MauiAppExample.Data;
using MauiAppExample.Model;

namespace MauiAppExample.Data.Abstractions
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> CreateAsync(Post p, Media m);
        Task<Stream> DownloadMediaAsync(Post p);
    }
}

