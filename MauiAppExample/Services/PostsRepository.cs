using System;
using MauiAppExample.Extensions;
using MauiAppExample.Model;

namespace MauiAppExample.Services;

public class PostsRepository
{
    private readonly HttpClient _client;

    public PostsRepository(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("services");
    }

    public async Task<IEnumerable<Post>> GetForCurrentUser()
    {
        var response = await _client.GetJson<StrapiResponse<Post>>($"/api/posts?populate=*");

        var result = response.Data.Select(x => x.Attributes);
        return result;
    }

}

