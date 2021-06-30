using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
           DataContext dataContext,
           ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }
        public async Task<Sacrament> ToSacramentAsync(SacramentViewModel model, bool isNew)
        {
            var sacrament = new Sacrament
            {
                SacramentName = model.SacramentName,
                Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId)
            };

            return sacrament;
        }

        public SacramentViewModel ToSacramentViewModel(Sacrament sacrament)
        {
            return new SacramentViewModel
            {
                SacramentName = sacrament.SacramentName,
                Parishioner = sacrament.Parishioner,
                SacramentId = sacrament.SacramentId,
                ParishionerId = sacrament.Parishioner.Id,
                SacramentTypes = _combosHelper.GetComboSacraments()
            };
        }

        public async Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew)
        {
            return new History
            {
                Date = model.Date.ToUniversalTime(),
                Description = model.Description,
                Id = isNew ? 0 : model.Id, 
                Sacrament = await _dataContext.Sacraments.FindAsync(model.SacramentId), 
                RequestType = await _dataContext.RequestTypes.FindAsync(model.RequestTypeId)
            };
        }

        public HistoryViewModel ToHistoryViewModel(History history)
        {
            return new HistoryViewModel
            {
                Date = history.Date,
                Description = history.Description,
                Id = history.Id,
                SacramentId = history.Sacrament.SacramentId,
                RequestTypeId = history.RequestType.Id,
                RequestTypes = _combosHelper.GetComboRequestTypes()
            };
        }
    }
}
