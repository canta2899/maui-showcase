using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppExample.ViewModel;

public class ProductPageViewModel : BaseViewModel 
{

    private string _msg;

    public string Msg
    {
        get => _msg;
        set => SetProperty(ref _msg, value);
    }

    public ProductPageViewModel()
    {
        Msg = "Sei proprio un simpaticone";
    }
}