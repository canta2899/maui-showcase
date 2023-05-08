using System;
using System.Text.Json;

namespace MauiAppExample.Shared
{
    public static class HttpExtension
    {
        private static JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<T> ReadAsJson<T>(this HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, _options);
		}
    }
}

