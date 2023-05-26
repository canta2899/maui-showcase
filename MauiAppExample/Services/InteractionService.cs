using System;
namespace MauiAppExample.Services;

public class InteractionService : IInteractionService
{
    public async Task DisplayAlert(string title, string message, string buttonText)
    {
        await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
    }

    public async Task NavigateTo(string shellPath)
    {
        await Shell.Current.GoToAsync(shellPath);
    }
}

