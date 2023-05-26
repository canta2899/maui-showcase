using System;
namespace MauiAppExample.Services;

public interface IInteractionService
{
    Task NavigateTo(string shellPath);
    Task DisplayAlert(string title, string message, string buttonText);
}

