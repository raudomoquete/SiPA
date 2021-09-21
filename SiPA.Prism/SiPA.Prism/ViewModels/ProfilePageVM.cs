using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using SiPA.Common.Helpers;
using SiPA.Common.Models;
using SiPA.Common.Services;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class ProfilePageVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private ParishionerResponse _parishioner;
        private DelegateCommand _saveCommand;
        private DelegateCommand _changePasswordCommand;

        public ProfilePageVM(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Modify Profile";
            IsEnabled = true;
            Parishioner = JsonConvert.DeserializeObject<ParishionerResponse>(Settings.Parishioner);
        }

        public DelegateCommand ChangePasswordCommand => _changePasswordCommand ?? (_changePasswordCommand = new DelegateCommand(ChangePassword));

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(Save));


        public ParishionerResponse Parishioner
        {
            get => _parishioner;
            set => SetProperty(ref _parishioner, value);
        }

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

        public IApiService ApiService => _apiService;

        private async void Save()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var userRequest = new UserRequest
            {
                Address = Parishioner.Address,
                Email = Parishioner.Email,
                FirstName = Parishioner.FirstName,
                LastName = Parishioner.LastName,
                Password = "123456", // It doesn't matter what is sent here. It is only for the model to be valid
                PhoneNumber = Parishioner.PhoneNumber
            };

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await ApiService.PutAsync(
                url,
                "/api",
                "/Account",
                userRequest,
                "bearer",
                token.Token);

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

            Settings.Parishioner = JsonConvert.SerializeObject(Parishioner);

            await App.Current.MainPage.DisplayAlert(
                "Ok",
                "User updated succesfully.",
                "Accept");
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(Parishioner.FirstName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a FirstName.", "Accept");
                return false;
            }

            if (string.IsNullOrEmpty(Parishioner.LastName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a LastName.", "Accept");
                return false;
            }

            if (string.IsNullOrEmpty(Parishioner.Address))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an Address.", "Accept");
                return false;
            }

            return true;
        }

        private async void ChangePassword()
        {
            await _navigationService.NavigateAsync("ChangePasswordPage");
        }
    }
}
