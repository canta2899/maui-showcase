using System;
using MauiAppExample.Services.Abstractions;

namespace MauiAppExample.Tests.Mockups;

public class UIServiceMockup : IUIService
{
    public Task DisplayAlertAsync(string title, string message, string buttonText)
    {
        return Task.Run(() => Console.WriteLine($"{title} - {message} - {buttonText}"));
    }

    public Task NavigateToAsync(string shellPath)
    {
        return Task.Run(() => Console.WriteLine($"{shellPath}"));
    }

    public Task NavigateToAsync(string shellPath, IDictionary<string, object> parameters)
    {
        return Task.Run(() => Console.WriteLine($"{shellPath}"));
    }
}

