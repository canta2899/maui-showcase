using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppExample.View;
using Security;

namespace MauiAppExample.ViewModel;

public class MainPageViewModel : BaseViewModel 
{

   public Command NavigateCommand { get;  } 

   public MainPageViewModel()
   {
      NavigateCommand = new Command(async () =>
      {
         await Shell.Current.GoToAsync(nameof(ProductPage));
      });
   }

   private static string GetRandomString(int length)
   {
      var rnd = new Random();
      var byteArray = new byte[length];
      rnd.NextBytes(byteArray);
      return Encoding.UTF8.GetString(byteArray);
   }
}