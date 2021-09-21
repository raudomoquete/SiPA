using Prism.Navigation;


namespace SiPA.Prism.ViewModels
{
    public class RequestPageVM : ViewModelBase
    {
        public RequestPageVM(INavigationService navigationService) : base(navigationService)
        {
            Title = "Request";
        }
    }
}
