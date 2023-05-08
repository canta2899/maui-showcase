using System;
using System.Text;
using System.Text.Json;
using MauiAppExample.Data;
using MauiAppExample.Extensions;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
        }

        public bool IsAuthenticated => false;

        public string AccessToken { get; private set; }

        public User CurrentUser { get; private set; }

        public void UpdateAuthentication(AuthenticationResponse authResponse)
        {
            AccessToken = authResponse.Jwt;
            CurrentUser = authResponse.User;
        }
    }

}

