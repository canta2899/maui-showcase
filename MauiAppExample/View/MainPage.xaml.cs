using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _vm;

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = _vm = vm;
    }
}