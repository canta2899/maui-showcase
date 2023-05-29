using System;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Data.Abstractions;

public interface IAuthRepository
{
    Task LoginAsync(AuthenticationRequest authRequest);
    void Logout();
}

