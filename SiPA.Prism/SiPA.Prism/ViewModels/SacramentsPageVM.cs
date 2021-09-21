using Newtonsoft.Json;
using Prism.Navigation;
using SiPA.Common.Helpers;
using SiPA.Common.Models;
using SiPA.Common.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class SacramentsPageVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ParishionerResponse _parishioner;
        private ObservableCollection<SacramentItemVM> _sacraments;
        //private DelegateCommand _addPetCommand;
        private static SacramentsPageVM _instance;
        public SacramentsPageVM(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Sacraments";
            LoadParishioner();
        }

        public ObservableCollection<SacramentItemVM> Sacraments
        {
            get => _sacraments;
            set => SetProperty(ref _sacraments, value);
        }

        public static SacramentsPageVM GetInstance()
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
                var owner = (ParishionerResponse)response.Result;
                Settings.Parishioner = JsonConvert.SerializeObject(owner);
                _parishioner = owner;
                LoadParishioner();
            }
        }

        private void LoadParishioner()
        {
            _parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(Settings.Parishioner);
            Title = $"Sacraments of: { _parishioner.FirstName}";
            Sacraments = new ObservableCollection<SacramentItemVM>(_parishioner.Sacraments.Select(s => new SacramentItemVM(_navigationService)
            {
                Christening = s.Christening,
                FirstCommunion = s.FirstCommunion,
                Confirmation = s.Confirmation,
                Wedding = s.Wedding
            }).ToList());
        }
    }
}
