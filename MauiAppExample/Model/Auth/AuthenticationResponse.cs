using System;
namespace MauiAppExample.Model.Auth;

public class AuthenticationResponse
{
    public string Jwt { get; set; }

    public User User { get; set; }
}

