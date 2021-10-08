using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using SiPA.Prism.Helpers;
using SiPA.Prism.Models;
using SiPA.Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class RequestsViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ParishionerResponse _parishioner;
        private ObservableCollection<RequestItemViewModel> _requests;
        private DelegateCommand _addRequestCommand;
        private static RequestsViewModel _instance;

        public RequestsViewModel(
            INavigationService navigationService,
            IApiService apiService): base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Solicitudes";
            LoadParishioner();
        }

        public DelegateCommand AddRequestCommand => _addRequestCommand ?? (_addRequestCommand = new DelegateCommand(AddRequest));

        public ObservableCollection<RequestItemViewModel> Requests
        {
            get => _requests;
            set => SetProperty(ref _requests, value);
        }

        public static RequestsViewModel GetInstance()
        {
            return _instance;
        }

        public async Task UpdateParishionerAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var response = await _apiService.GetParishionerByEmailAsync(
                url,
                "/api",
                "/Parishioners/GetParishionerByEmail",
                "bearer",
                token.Token,
                _parishioner.Email);

            if (response.IsSuccess)
            {
                var parishioner = (ParishionerResponse)response.Result;
                Settings.Parishioner = JsonConvert.SerializeObject(parishioner);
                _parishioner = parishioner;
                LoadParishioner();
            }
        }

        private void LoadParishioner()
        {
            _parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(Settings.Parishioner);
            Title = $"Solicitudes de: {_parishioner.FullName}";
            Requests = new ObservableCollection<RequestItemViewModel>(_parishioner.Requests.Select(p => new RequestItemViewModel(_navigationService)
            {
                RequestDate = p.RequestDate,
                RequestType = p.RequestType
            }).ToList());
        }

        private async void AddRequest()
        {
            await _navigationService.NavigateAsync("EditRequestPage");
        }
    }
}
