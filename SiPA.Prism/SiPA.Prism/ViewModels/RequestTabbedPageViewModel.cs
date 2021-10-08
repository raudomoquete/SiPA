using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Helpers;
using SiPA.Prism.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiPA.Prism.ViewModels
{
    public class RequestTabbedPageViewModel : ViewModelBase
    {
        public RequestTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var request = JsonConvert.DeserializeObject<RequestResponse>(Settings.Request);
            Title = $"Request: {request.RequestType}";
        }
    }
}
