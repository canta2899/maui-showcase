using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppExample.ViewModel;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected IServiceProvider ServiceProvider { get; }

    protected Action<object> ToAsync(Func<object, Task> asyncAction)
    {
        return async (o) => await asyncAction(o);
    }
}