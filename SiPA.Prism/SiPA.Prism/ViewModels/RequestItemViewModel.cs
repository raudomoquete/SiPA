using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using SiPA.Prism.Helpers;
using SiPA.Prism.Models;

namespace SiPA.Prism.ViewModels
{
    public class RequestItemViewModel : RequestResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectRequestCommand;

        public RequestItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectRequestCommand => _selectRequestCommand ?? 
            (_selectRequestCommand = new DelegateCommand(SelectRequest));

        private async void SelectRequest()
        {
            Settings.Request = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("RequestTabbedPage");
        }
    }
}
