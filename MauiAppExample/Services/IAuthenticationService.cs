using System;
using MauiAppExample.Data;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; }

    public string AccessToken { get; }

    public User CurrentUser { get; }

    public void UpdateAuthentication(AuthenticationResponse authResponse);
}

