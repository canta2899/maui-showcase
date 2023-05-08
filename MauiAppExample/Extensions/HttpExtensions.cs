using System;
using System.Text;
using MauiAppExample.Data;

namespace MauiAppExample.Extensions;

/// <summary>
/// Extension methods for the HttpClient
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// Performs a POST request with the provided payload and returns 
    /// the deserialized response
    /// </summary>
    /// <typeparam name="T">The response type</typeparam>
    /// <param name="client">The current HTTP client</param>
    /// <param name="endpoint">The request endpoint</param>
    /// <param name="payload">The request payload</param>
    /// <returns>The deserialized response</returns>
    /// <exception cref="HttpRequestException"> </exception>
    /// <exception cref="SerializerException"> </exception>

    public static async Task<T> PostJson<T>(this HttpClient client, string endpoint, object payload)
    {
        var content = new StringContent(
		    payload.ToJson(),
		    Encoding.UTF8,
		    "application/json");

        var response = await client.PostAsync(endpoint, content);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString.FromJson<T>();
    }
}

