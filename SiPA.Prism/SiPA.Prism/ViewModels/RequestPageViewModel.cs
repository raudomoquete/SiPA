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
    public class RequestPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RequestResponse _request;
        private DelegateCommand _editRequestCommand;

        public RequestPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Detalles";
        }

        public DelegateCommand EditRequestCommand => _editRequestCommand ?? (_editRequestCommand = new DelegateCommand(EditRequestAsync));

        public RequestResponse Request
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Request = JsonConvert.DeserializeObject<RequestResponse>(Settings.Request);
        }

        private async void EditRequestAsync()
        {
            var parameters = new NavigationParameters
            {
                {"request", Request }
            };

            await _navigationService.NavigateAsync("EditRequestPage", parameters);
        }      
    }
}
