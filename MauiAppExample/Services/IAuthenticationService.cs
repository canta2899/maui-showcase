using System;
using MauiAppExample.Data;

namespace MauiAppExample.Services;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; }

    public Response Login(string userName, string password);
}

