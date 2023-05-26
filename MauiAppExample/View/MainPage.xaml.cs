using CommunityToolkit.Mvvm.Messaging;
using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}