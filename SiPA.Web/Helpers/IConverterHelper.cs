﻿using SiPA.Web.Data.Entities;
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

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);

        //HistoryViewModel ToHistoryViewModel(History history);

        //Task<Christening> ToChristeningAsync(ChristeningViewModel model, bool isNew);

        //ChristeningViewModel ToChristeningViewModel(Christening christening);

    }
}
