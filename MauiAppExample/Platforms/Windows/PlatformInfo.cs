using MauiAppExample.Services;

namespace MauiAppExample.Platforms;

public class PlatformInfo : IPlatformInfo
{
    public string GetPlatform()
    {
        return "windows";
    }
}


