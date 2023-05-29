using System;
using MauiAppExample.Data;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Extensions;
using MauiAppExample.Model;

namespace MauiAppExample.Data.Implementations;

public class PostsRepository : IPostsRepository
{
    private readonly HttpClient _client;

    public PostsRepository(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("services");
    }


    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var query = "/api/posts?populate=*&sort=createdAt:desc";
        var response = await _client.GetJson<ApiMultiEntry<Post>>(query);

        return response.Data.Select(x => x.Attributes);
    }


    public async Task<Post> CreateAsync(Post post, Media media)
    {
        var data = new { post.Title, post.FullText };

        var multipartForm = GetMultiPartFormData(data, media);

        var response = await _client.PostJson<ApiSingleEntry<Post>>("/api/posts", multipartForm);

        return response.Data.Attributes;
    }


    private MultipartFormDataContent GetMultiPartFormData(object data, Media media)
    {
        var content = new StreamContent(media.Content);
        content.Headers.ContentType = new(MimeTypes.GetMimeType(media.Name));

        return new MultipartFormDataContent
        {
            {new StringContent(data.ToJson()), "data"},
            {content, "files.asset", media.Name },
        };
    }


    public async Task<Stream> DownloadMediaAsync(Post post)
    {
        return await _client.GetStreamAsync(post.Asset.Data.Attributes.Url);
    }
}

