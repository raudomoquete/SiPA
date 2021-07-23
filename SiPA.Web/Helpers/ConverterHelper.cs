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

        public async Task<Christening> ToChristeningAsync(ChristeningViewModel model, bool isNew)
        {
            var christening = new Christening
            {
                ChristeningDate = model.ChristeningDate,
                Id = isNew ? 0 : model.Id,
                PlaceofEvent = model.PlaceofEvent,
                FatherName = model.FatherName,
                FatherId = model.FatherId,
                MotherName = model.MotherName,
                MotherId = model.MotherId,
                GodFatherName = model.GodFatherName,
                GodFatherId = model.GodFatherId,
                GodMotherName = model.GodMotherName,
                GodMotherId = model.GodMotherId,
                Comments = model.Comments,
                CeremonialCelebrant = model.CeremonialCelebrant,
                Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId),
                SacramentType = await _dataContext.SacramentTypes.FindAsync(model.SacramentTypeId)
            };

            return christening;
        }

        public ChristeningViewModel ToChristeningViewModel(Christening christening)
        {
            return new ChristeningViewModel
            {
                ChristeningDate = christening.ChristeningDate,
                Id = christening.Id,
                PlaceofEvent = christening.PlaceofEvent,
                Parishioner = christening.Parishioner,
                FatherName = christening.FatherName,
                FatherId = christening.FatherId,
                MotherName = christening.MotherName,
                MotherId = christening.MotherId,
                GodFatherName = christening.GodFatherName,
                GodFatherId = christening.GodFatherId,
                GodMotherName = christening.GodMotherName,
                GodMotherId = christening.GodMotherId,
                Comments = christening.Comments,
                CeremonialCelebrant = christening.CeremonialCelebrant,
                ParishionerId = christening.Parishioner.Id,
                SacramentTypeId = christening.SacramentType.Id,
                SacramentTypes = _combosHelper.GetComboSacraments()
            };
        }

        public async Task<FirstCommunion> ToFirstCommunionAsync(FirstCommunionViewModel model, bool isNew)
        {
            var firstCommunion = new FirstCommunion
            {
                FirstCommunionDate = model.FirstCommunionDate,
                Id = isNew ? 0 : model.Id,
                PlaceofEvent = model.PlaceofEvent,
                FatherName = model.FatherName,
                FatherId = model.FatherId,
                MotherName = model.MotherId,
                Comments = model.Comments,
                CeremonialCelebrant = model.CeremonialCelebrant,
                Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId),
                SacramentType = await _dataContext.SacramentTypes.FindAsync(model.SacramentTypeId)
            };

            return firstCommunion;
        }

        public FirstCommunionViewModel ToFirstCommunionViewModel(FirstCommunion firstCommunion)
        {
            return new FirstCommunionViewModel
            {
                FirstCommunionDate = firstCommunion.FirstCommunionDate,
                Id = firstCommunion.Id,
                PlaceofEvent = firstCommunion.PlaceofEvent,
                Parishioner = firstCommunion.Parishioner,
                FatherName = firstCommunion.FatherName,
                FatherId = firstCommunion.FatherId,
                MotherName = firstCommunion.MotherName,
                MotherId = firstCommunion.MotherId,
                Comments = firstCommunion.Comments,
                CeremonialCelebrant = firstCommunion.CeremonialCelebrant,
                SacramentTypeId = firstCommunion.SacramentType.Id,
                SacramentTypes = _combosHelper.GetComboSacraments()
            };
        }

        public async Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew)
        {
            return new History
            {
                Description = model.Description,
                Id = isNew ? 0 : model.Id, 
               // SacramentType = await _dataContext.SacramentTypes.FindAsync(model.SacramentId), 
                RequestType = await _dataContext.RequestTypes.FindAsync(model.RequestTypeId)
            };
        }

        //public HistoryViewModel ToHistoryViewModel(History history)
        //{
        //    return new HistoryViewModel
        //    {
        //        Date = history.Date,
        //        Description = history.Description,
        //        Id = history.Id,
        //        SacramentId = history.Sacrament.SacramentId,
        //        RequestTypeId = history.RequestType.Id,
        //        RequestTypes = _combosHelper.GetComboRequestTypes()
        //    };
        //}

        //public async Task<Christening> ToChristeningAsync(ChristeningViewModel model, bool isNew)
        //{
        //    var christening = new Christening
        //    {
        //        ChristeningDate = model.ChristeningDate,
        //        Certificate = model.Certificate,
        //        Id = isNew ? 0 : model.Id,
        //        PlaceofEvent = model.PlaceofEvent,
        //        FatherName = model.FatherName,
        //        FatherId = model.FatherId,
        //        MotherName = model.MotherName,
        //        MotherId = model.MotherId,
        //        GodFatherName = model.GodFatherName,
        //        GodFatherId = model.GodFatherId,
        //        GodMotherName = model.GodMotherName,
        //        GodMotherId = model.GodMotherId,
        //        Comments = model.Comments,
        //        CeremonialCelebrant = model.CeremonialCelebrant,
        //        Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId)
        //    };

        //    return christening;
        //}

        //public ChristeningViewModel ToChristeningViewModel(Christening christening)
        //{
        //    return new ChristeningViewModel
        //    {
        //        ChristeningDate = christening.ChristeningDate,
        //        Certificate = christening.Certificate,
        //        Id = christening.Id,
        //        PlaceofEvent = christening.PlaceofEvent,
        //        FatherName = christening.FatherName,
        //        FatherId = christening.FatherId,
        //        MotherName = christening.MotherName,
        //        MotherId = christening.MotherId,
        //        GodFatherName = christening.GodFatherName,
        //        GodFatherId = christening.GodFatherId,
        //        GodMotherName = christening.GodMotherName,
        //        GodMotherId = christening.GodMotherId,
        //        Comments = christening.Comments,
        //        CeremonialCelebrant = christening.CeremonialCelebrant,
        //        Parishioner = christening.Parishioner,
        //        ParishionerId = christening.Parishioner.Id
        //    };
        //}
    }
}
