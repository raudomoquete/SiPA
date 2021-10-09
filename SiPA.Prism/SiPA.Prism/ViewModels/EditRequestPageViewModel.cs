using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using SiPA.Prism.Helpers;
using SiPA.Prism.Models;
using SiPA.Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class EditRequestPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private RequestResponse _request;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isEdit;
        private ObservableCollection<RequestTypeResponse> _requestTypes;
        private RequestTypeResponse _requestType;
        private DelegateCommand _saveCommand;


        public EditRequestPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            IsEnabled = true;
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAsync));

        public ObservableCollection<RequestTypeResponse> RequestTypes
        {
            get => _requestTypes;
            set => SetProperty(ref _requestTypes, value);
        }

        public RequestTypeResponse RequestType
        {
            get => _requestType;
            set => SetProperty(ref _requestType, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEdit
        {
            get => _isEdit;
            set => SetProperty(ref _isEdit, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public RequestResponse Request
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("request"))
            {
                Request = parameters.GetValue<RequestResponse>("request");
                IsEdit = true;
                Title = "Editar Solicitud";
            }
            else
            {
                Request = new RequestResponse { RequestDate = DateTime.Today };
                IsEdit = false;
                Title = "Nueva Solicitud";
            }

            LoadRequestAsync();
        }

        private async void LoadRequestAsync()
        {
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();

            var connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Verifica la conexion a internet.",
                    "Aceptar");
                await _navigationService.GoBackAsync();
                return;
            }

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var response = await _apiService.GetListAsync<RequestTypeResponse>(
                url,
                "/api",
                "/RequestTypes",
                "bearer",
                token.Token);

            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Obteniendo los tipos de solicitud, por favor trata mas tarde,",
                    "Aceptar");
                await _navigationService.GoBackAsync();
                return;
            }

            var requestTypes = (List<RequestTypeResponse>)response.Result;
            RequestTypes = new ObservableCollection<RequestTypeResponse>(requestTypes);

            if (!string.IsNullOrEmpty(Request.RequestType))
            {
                RequestType = RequestTypes.FirstOrDefault(rt => rt.Name == Request.RequestType);
            }
        }

        private async void SaveAsync()
        {
            var isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            var parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(Settings.Parishioner);

            var certificateRequest = new CertificateRequest
            {
                RequestDate = Request.RequestDate,
                Id = Request.Id,
                ParishionerId = parishioner.Id,
                RequestTypeId = RequestType.Id
            };

            Response<object> response;
            if (IsEdit)
            {
                response = await _apiService.PutAsync(
                    url, "/api", "/Requests", certificateRequest.Id, certificateRequest, "bearer", token.Token);
            }
            else
            {
                response = await _apiService.PostAsync(
                    url, "/api", "/Requests", certificateRequest, "bearer", token.Token);
            }

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                     "Error",
                    "Agregando el tipo de solicitud, por favor trata mas tarde,",
                    "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert(
                "Aceptar",
                ".",
                IsEdit ? "La Solicitud ha sido editada" : "La Solicitud ha sido agregada",
                "Aceptar");

            await RequestsViewModel.GetInstance().UpdateParishionerAsync();

            await _navigationService.GoBackToRootAsync();
        }

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(RequestType.Name))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Esto esta mal", "Aceptar");
                return false;
            }

            if (Request == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No encuentro el tipo de requerimiento", "Aceptar");
                return false;
            }

            return true;
        }        
    }
}
