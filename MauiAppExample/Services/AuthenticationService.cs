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

        public async Task Init()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }
    }

}

