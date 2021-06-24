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
        Task<Sacrament> ToSacramentAsync(SacramentViewModel model, bool isNew);

        SacramentViewModel ToSacramentViewModel(Sacrament sacrament);

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);

        HistoryViewModel ToHistoryViewModel(History history);
    }
}
