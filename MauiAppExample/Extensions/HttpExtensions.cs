using System;
using System.Text;
using System.Web;
using MauiAppExample.Data;

namespace MauiAppExample.Extensions;

/// <summary>
/// Extension methods for the HttpClient
/// </summary>
public static class HttpExtensions
{
    private static async Task<T> ReadAndDeserializeAsync<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        return responseString.FromJson<T>();
    }

    public static async Task<T> PostJson<T>(this HttpClient client, string endpoint, object payload)
    {
        var content = new StringContent(
            payload.ToJson(),
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync(endpoint, content);

        return await ReadAndDeserializeAsync<T>(response);
    }

    public static async Task<T> PostJson<T>(this HttpClient client, string endpoint, HttpContent content)
    {
        var response = await client.PostAsync(endpoint, content);
        return await ReadAndDeserializeAsync<T>(response);
    }

    public static async Task<T> GetJson<T>(this HttpClient client, string endpoint)
    {
        var response = await client.GetAsync(endpoint);
        return await ReadAndDeserializeAsync<T>(response);
    }

    public static void AcceptOnlyJson(this HttpClient client)
    { 
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    }
}

