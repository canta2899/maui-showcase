using System;
using MauiAppExample.Data;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; }

    public string AccessToken { get; set; }

    public User CurrentUser { get; set; }
}

