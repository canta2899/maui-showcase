using System;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Services.Handlers;

public class StrapiClientAuthHandler : DelegatingHandler
{
    private readonly IAuthenticationService _authService; 

    public StrapiClientAuthHandler(IAuthenticationService authService)
    {
        _authService = authService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // set authorization header to each request if the user is authenticated
        if (_authService.IsAuthenticated)
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", _authService.AccessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}

