using System;
using MauiAppExample.Data;
using MauiAppExample.Extensions;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services;

public class AuthRepository
{
    private readonly HttpClient _client;
    private readonly IAuthenticationService _authService;

    public AuthRepository(HttpClient client, IAuthenticationService authService)
    {
        _client = client;
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

        _authService.AccessToken = response.Jwt;
        _authService.CurrentUser = response.User;

        return Response.Success;
    }

    public async Task Logout(string username, string password)
    { 
        throw new NotImplementedException("Not implemented");
    }
}

