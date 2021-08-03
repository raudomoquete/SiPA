using SiPA.Web.Data.Entities;
using SiPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Christening> ToChristeningAsync(ChristeningViewModel model, bool isNew);

        ChristeningViewModel ToChristeningViewModel(Christening christening);

        Task<FirstCommunion> ToFirstCommunionAsync(FirstCommunionViewModel model, bool isNew);

        FirstCommunionViewModel ToFirstCommunionViewModel(FirstCommunion firstCommunion);

        Task<Confirmation> ToConfirmationAsync(ConfirmationViewModel model, bool isNew);

        ConfirmationViewModel ToConfirmationViewModel(Confirmation confirmation);

        Task<Wedding> ToWeddingAsync(WeddingVM model, bool isNew);

        WeddingVM ToWeddingVM(Wedding wedding);


        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);

        //HistoryViewModel ToHistoryViewModel(History history);

        //Task<Christening> ToChristeningAsync(ChristeningViewModel model, bool isNew);

        //ChristeningViewModel ToChristeningViewModel(Christening christening);

    }
}
