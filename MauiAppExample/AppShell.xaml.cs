using MauiAppExample.View;

namespace MauiAppExample;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
    }
}