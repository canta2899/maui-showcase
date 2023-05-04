using MauiAppExample.ViewModel;

namespace MauiAppExample.View;

public partial class ProductPage : ContentPage
{
    int count = 0;
    private ProductPageViewModel _vm;

    public ProductPage(ProductPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = _vm = vm;
    }
}