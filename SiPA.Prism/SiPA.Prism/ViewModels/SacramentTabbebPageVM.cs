using Newtonsoft.Json;
using Prism.Navigation;
using SiPA.Common.Helpers;
using SiPA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Prism.ViewModels
{
    public class SacramentTabbebPageVM : ViewModelBase
    {
        public SacramentTabbebPageVM(INavigationService navigationService) : base(navigationService)
        {
            var s1 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Christening);
            Title = $"Sacrament: {s1.Christening}";

            var s2 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.FirstCommunion);
            Title = $"Sacrament: {s2.FirstCommunion}";

            var s3 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Confirmation);
            Title = $"Sacrament: {s3.Confirmation}";

            var s4 = JsonConvert.DeserializeObject<SacramentResponse>(Settings.Wedding);
            Title = $"Sacrament: {s4.Wedding}";
        }
    }
}
