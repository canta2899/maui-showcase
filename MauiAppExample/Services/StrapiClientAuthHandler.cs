using System;
namespace MauiAppExample.Services;

/// <summary
/// Configures JWT token on each request before sending it
/// </summary>
public class StrapiClientAuthHandler : DelegatingHandler
{
    private readonly IAuthenticationService _authService; 

    /// <summary>
    /// Initializes the class with the default authentication service
    /// </summary>
    /// <param name="authService">The authentication service</param>
    public StrapiClientAuthHandler(IAuthenticationService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Intercepts SendAsync and sets the Authentication Header
    /// </summary>
    /// <param name="request">The outgoing http request</param>
    /// <param name="cancellationToken">the request cancellation token</param>
    /// <returns>the awaited response/returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(_authService.AccessToken))
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", _authService.AccessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}

