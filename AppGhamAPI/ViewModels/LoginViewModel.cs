using AppGhamAPI.Views;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AppGhamAPI.Client;
using Shared;

namespace AppGhamAPI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(LoginAsync);
        }

        public ICommand LoginCommand { get; }

        public string Username { get; set; }

        public string Password { get; set; }

        private async Task LoginAsync()
        {

            var result = await ApiClient.PostAsync<User, bool>("login", new User { Username = "teste", Password = "teste" });

            await Application.Current.MainPage.DisplayAlert("Login", $"result: {result}", "Ok");

            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
