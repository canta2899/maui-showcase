using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class InsertPage : ContentPage 
{
    public InsertPage(InsertPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}