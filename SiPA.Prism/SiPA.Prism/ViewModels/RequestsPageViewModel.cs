using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SiPA.Prism.ViewModels
{
    public class RequestsPageViewModel : ViewModelBase
    {
        private ParishionerResponse _parishioner;
        private ObservableCollection<RequestResponse> _request; //Observable por si hacemos un cambio en la lista se refleje en el otro lado


        public RequestsPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Solicitudes";
        }

        public ObservableCollection<RequestResponse> Requests
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("parishioner"))
            {
                _parishioner = parameters.GetValue<ParishionerResponse>("parishioner");
                Title = $"Solicitudes de: {_parishioner.FullName}";
                Requests = new ObservableCollection<RequestResponse>(_parishioner.Requests);
            }
        }
    }
}
