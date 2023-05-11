using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppExample.ViewModel;

public class InsertPageViewModel : BaseViewModel 
{

    private string _msg;

    public string Msg
    {
        get => _msg;
        set => SetProperty(ref _msg, value);
    }

    public InsertPageViewModel()
    {
        Msg = "A message";
    }
}