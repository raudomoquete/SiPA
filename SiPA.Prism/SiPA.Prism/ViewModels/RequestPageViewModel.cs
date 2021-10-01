using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Models;
using SiPA.Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class RequestPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _addRequestCommand;

        public RequestPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;

            Title = "Solicitar Acta Sacramental";
            IsEnabled = true;
        }

        public DelegateCommand RegisterCommand => _addRequestCommand ?? (_addRequestCommand = new DelegateCommand(AddRequest));

        public DateTime? RequestDate { get; set; }
        public string RequestType { get; set; }

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

        private async void AddRequest()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new RequestResponse
            {
                RequestDate = RequestDate,
                RequestType = RequestType
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.AddRequestAsync(
                url,
                "api",
                "/Requests",
                request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            await App.Current.MainPage.DisplayAlert(
           "Ok",
           response.Message,
           "Accept");
            await _navigationService.GoBackAsync();
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(RequestType))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes elegir un tipo de solicitud.", "Accept");
                return false;
            }

            return true;
        }

    }
}
