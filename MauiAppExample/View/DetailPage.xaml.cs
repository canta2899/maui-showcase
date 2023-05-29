using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}
