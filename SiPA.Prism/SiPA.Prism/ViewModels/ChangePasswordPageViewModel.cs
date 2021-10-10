using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Helpers;
using SiPA.Prism.Models;
using SiPA.Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class ChangePasswordPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _changePasswordCommand;

        public ChangePasswordPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            IsEnabled = true;
            Title = "Cambiar Password";
        }

        public DelegateCommand ChangePasswordCommand => _changePasswordCommand ?? (_changePasswordCommand = new DelegateCommand(ChangePassword));

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string PasswordConfirm { get; set; }

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

        private async void ChangePassword()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(Settings.Parishioner);
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var request = new ChangePasswordRequest
            {
                Email = parishioner.Email,
                NewPassword = NewPassword,
                OldPassword = CurrentPassword
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.ChangePasswordAsync(
                url,
                "/api",
                "/Account/ChangePassword",
                request,
                "bearer",
                token.Token);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "No pudimos cambiar tu password",
                    "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert(
                "Ok",
                "Password cambiado satisfactoriamente.",
                "Aceptar");

            await _navigationService.GoBackAsync();
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(CurrentPassword))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes escribir el password actual.",
                    "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(NewPassword) || NewPassword?.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "El password debe tener al menos 6 caracteres.",
                    "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes confirmar el password.",
                    "Aceptar");
                return false;
            }

            if (!NewPassword.Equals(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "El nuevo password y el password confirmado no son iguales.",
                    "Aceptar");
                return false;
            }

            return true;
        }
    }
}
