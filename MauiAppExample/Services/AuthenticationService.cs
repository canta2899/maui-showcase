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

        public bool IsAuthenticated => string.IsNullOrEmpty(AccessToken);

        public string AccessToken { get; set; }

        public User CurrentUser { get; set; }
    }

}

