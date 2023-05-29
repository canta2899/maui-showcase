using System;
namespace MauiAppExample;

public static class Shared
{
    public static readonly string ApiServiceUrl = "http://localhost:1337";
    public static readonly string ApiAuthUrl = "http://localhost:1337";
    public static string GetDownloadUrl(string uri) => $"{ApiServiceUrl}{uri}";
}

