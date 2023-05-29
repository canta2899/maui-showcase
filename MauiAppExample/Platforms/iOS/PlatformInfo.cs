using MauiAppExample.Services;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Platforms;

public class PlatformInfo : IPlatformInfo
{
    public string GetPlatform()
    {
        return $"{UIKit.UIDevice.CurrentDevice.Name}";
    }
}

