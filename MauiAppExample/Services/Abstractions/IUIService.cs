using System;
namespace MauiAppExample.Services.Abstractions;

public interface IUIService
{
    Task NavigateToAsync(string shellPath);
    Task NavigateToAsync(string shellPath, IDictionary<string, object> parameters);
    Task DisplayAlertAsync(string title, string message, string buttonText);
}

