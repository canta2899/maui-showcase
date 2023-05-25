using System;
using MauiAppExample.Data;
using MauiAppExample.Extensions;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services;

public class AuthRepository
{
    private readonly HttpClient _client;
    private readonly IAuthenticationService _authService;

    public AuthRepository(IHttpClientFactory httpClientFactory, IAuthenticationService authService)
    {
        _client = httpClientFactory.CreateClient("auth");
        _authService = authService;
    }

    public async Task<Response> Login(AuthenticationRequest authRequest)
    {
        AuthenticationResponse response;

        try
        { 
          response = await _client.PostJson<AuthenticationResponse>("/api/auth/local", authRequest);
        }
        catch (Exception ex)
        {
            return Response.Error(ex.Message);
        }

        await _authService.UpdateAsync(response);

        return Response.Success;
    }

    public void Logout()
    {
        _authService.Clear();
    }
}

