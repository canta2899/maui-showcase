using System;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Tests.Mockups
{
    public class AuthenticationServiceMockup : IAuthenticationService
    {
        public bool IsAuthenticated => throw new NotImplementedException();

        public string AccessToken => throw new NotImplementedException();

        public User CurrentUser => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Task InitAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AuthenticationResponse authResponse)
        {
            throw new NotImplementedException();
        }
    }
}

