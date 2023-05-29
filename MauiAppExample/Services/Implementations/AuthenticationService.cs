using MauiAppExample.Extensions;
using MauiAppExample.Model.Auth;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken);

        public string AccessToken { get; private set; }

        public User CurrentUser { get; private set; }

        public void Clear()
        {
            SecureStorage.Default.Remove("jwt");
            SecureStorage.Default.Remove("user");
        }

        public async Task InitAsync()
        {
            var user = await SecureStorage.Default.GetAsync("user");
            var jwt = await SecureStorage.Default.GetAsync("jwt");

            if (!string.IsNullOrEmpty(user))
                CurrentUser = user.FromJson<User>();

            if (!string.IsNullOrEmpty(jwt))
                AccessToken = jwt;
        }

        public async Task UpdateAsync(AuthenticationResponse authResponse)
        {
            AccessToken = authResponse.Jwt;
            CurrentUser = authResponse.User;
            await SecureStorage.Default.SetAsync("jwt", AccessToken);
            await SecureStorage.Default.SetAsync("user", CurrentUser.ToJson());
        }
    }

}

