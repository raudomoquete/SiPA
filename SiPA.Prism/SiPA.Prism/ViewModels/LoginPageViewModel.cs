using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Models;
using SiPA.Prism.Services;
using System;

namespace SiPA.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;
        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "SiPA - Login";
            IsEnabled = true;

        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));
        public string Email { get; set; }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
        private async void Login()
        {
            if (
          string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                UserName = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }

            var token = (TokenResponse)response.Result;
            var response2 = await _apiService.GetParishionerByEmailAsync(url, "api", "/Parishioners/GetParishionerByEmailAsync", "bearer", token.Token, Email);

            if (!response2.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "hay problemas, llama a soporte.", "Accept");
                return;
            }

            var parishioner = (ParishionerResponse)response2.Result;
            var parameters = new NavigationParameters
            {
                { "parishioner", parishioner }
            };
            //parameters.Add("parishioner", parishioner); queda mejor como se puso en la linea 95

            IsRunning = false;
            IsEnabled = true;

            await _navigationService.NavigateAsync("RequestPage", parameters);
            Password = string.Empty;
        }
    }
}
