using System;
using MauiAppExample.Data;
using MauiAppExample.Extensions;
using MauiAppExample.Model;
using MauiAppExample.Model.Auth;

namespace MauiAppExample.Services
{
    public class StrapiClient
    {
        private static readonly string STRAPI_BASE_URL = "http://localhost:1337";

        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authService;

        public StrapiClient(HttpClient httpClient, IAuthenticationService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
            _httpClient.BaseAddress = new Uri(STRAPI_BASE_URL);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<T> GetJson<T>(string endpoint)
        {
            return await _httpClient.GetJson<T>(endpoint);
        }

        public async Task<Response> Login(AuthenticationRequest authRequest)
        {
            AuthenticationResponse response;
            
            try
            { 
              response = await _httpClient.PostJson<AuthenticationResponse>("/api/auth/local", authRequest);
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }

            _authService.AccessToken = response.Jwt;
            _authService.CurrentUser = response.User;

            return Response.Success;
        }
    }
}

