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
    public class ServicesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private TokenResponse _token;
        private ParishionerResponse _parishioner;


        public ServicesPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Solicitudes";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("token"))
            {
                _token = parameters.GetValue<TokenResponse>("token");              
            }
            
            if (parameters.ContainsKey("parishioner"))
            {
                _parishioner = parameters.GetValue<ParishionerResponse>("parishioner");
                Title = _parishioner.FullName;
            }
        }
    }
}
