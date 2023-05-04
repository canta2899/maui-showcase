using System;
using MauiAppExample.Data;

namespace MauiAppExample.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
        }

        public bool IsAuthenticated => false;

        public Response Login(string userName, string password)
        {
            var seconds = DateTime.Now.Second;
            return seconds % 2 == 0 ?
                    Response.Error("Errore brutto") :
                    Response.Success;
        }
    }
}

