using System;
using MauiAppExample.Services.Abstractions;
namespace MauiAppExample.Services.Implementations;

public class UIService : IUIService
{
    public async Task DisplayAlertAsync(string title, string message, string buttonText)
    {
        await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
    }

    public async Task NavigateToAsync(string shellPath)
    {
        await Shell.Current.GoToAsync(shellPath);
    }

    public async Task NavigateToAsync(string shellPath, IDictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(shellPath, true, parameters);
    }
}

