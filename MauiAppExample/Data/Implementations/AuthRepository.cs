using System;
using MauiAppExample.Data;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Extensions;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Data.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly HttpClient _client;
    private readonly IAuthenticationService _authService;

    public AuthRepository(IHttpClientFactory httpClientFactory, IAuthenticationService authService)
    {
        _client = httpClientFactory.CreateClient("auth");
        _authService = authService;
    }

    public async Task LoginAsync(AuthenticationRequest authRequest)
    {
        AuthenticationResponse response;
        response = await _client.PostJson<AuthenticationResponse>("/api/auth/local", authRequest);

        await _authService.UpdateAsync(response);
    }

    public void Logout()
    {
        _authService.Clear();
    }
}

