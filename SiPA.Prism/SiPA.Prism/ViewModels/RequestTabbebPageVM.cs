using Newtonsoft.Json;
using Prism.Navigation;
using SiPA.Common.Helpers;
using SiPA.Common.Models;

namespace SiPA.Prism.ViewModels
{
    public class RequestTabbebPageVM : ViewModelBase
    {
        public RequestTabbebPageVM(INavigationService navigationService) : base(navigationService)
        {
            var s1 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Christening);
            Title = $"RequestType: {s1.Christening}";

            var s2 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.FirstCommunion);
            Title = $"RequestType: {s2.FirstCommunion}";

            var s3 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Confirmation);
            Title = $"RequestType: {s3.Confirmation}";

            var s4 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Wedding);
            Title = $"RequestType: {s4.Wedding}";
        }
    }
}
