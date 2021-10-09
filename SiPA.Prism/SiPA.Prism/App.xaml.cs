using Prism;
using Prism.Ioc;
using SiPA.Prism.Services;
using SiPA.Prism.ViewModels;
using SiPA.Prism.Views;
using Xamarin.Forms;

namespace SiPA.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RequestPage, RequestPageViewModel>();
            containerRegistry.RegisterForNavigation<RequestTabbedPage, RequestTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<EditRequestPage, EditRequestPageViewModel>();
            containerRegistry.RegisterForNavigation<Requests, RequestsViewModel>();
            containerRegistry.RegisterForNavigation<SiPAMasterDetailPage, SiPAMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}
