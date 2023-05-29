using System;
using MauiAppExample.Data;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services.Abstractions;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; }

    public string AccessToken { get; }

    public User CurrentUser { get; }

    public Task InitAsync();

    public void Clear();

    public Task UpdateAsync(AuthenticationResponse authResponse);
}

