using System;
using MauiAppExample.Model;

namespace MauiAppExample.Services;

public class PostsRepository
{
    private readonly StrapiClient _client;

    public PostsRepository(StrapiClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Post>> GetForCurrentUser()
    {
        var response = await _client.GetJson<StrapiResponse<Post>>($"/api/posts");

        var result = response.Data.Select(x => x.Attributes);
        return result;
    }

}

