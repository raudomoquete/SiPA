using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using SiPA.Common.Helpers;
using SiPA.Common.Models;

namespace SiPA.Prism.ViewModels
{
    public class SacramentItemVM : SacramentResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectSacramentCommand;

        public SacramentItemVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPetCommand => _selectSacramentCommand ?? (_selectSacramentCommand = new DelegateCommand(SelectSacrament));

        private async void SelectSacrament()
        {
            Settings.Christening = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("SacramentTabbedPage");

            Settings.FirstCommunion = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("SacramentTabbedPage");

            Settings.Confirmation = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("SacramentTabbedPage");

            Settings.Wedding = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("SacramentTabbedPage");
        }
    }
}
