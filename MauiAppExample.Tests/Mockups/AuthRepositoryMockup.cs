using System;
using MauiAppExample.Data.Abstractions;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Tests.Mockups;

public class AuthRepositoryMockup : IAuthRepository
{
    public Task LoginAsync(AuthenticationRequest authRequest)
    {
        throw new NotImplementedException();
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }
}

