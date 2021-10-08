using SiPA.Prism.Models;
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

        public async Task<Confirmation> ToConfirmationAsync(ConfirmationViewModel model, bool isNew)
        {
            var confirmation = new Confirmation
            {
                PlaceofEvent = model.PlaceofEvent,
                Id = isNew ? 0 : model.Id,
                FatherName = model.FatherName,
                FatherId = model.FatherId,
                MotherName = model.MotherId,
                MotherId = model.MotherId,
                GodFatherName = model.GodFatherName,
                GodFatherId = model.GodFatherId,
                GodMotherName = model.GodMotherName,
                GodMotherId = model.GodMotherId,
                Comments = model.Comments,
                CeremonialCelebrant = model.CeremonialCelebrant,
                ConfirmationDate = model.ConfirmationDate,
                Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId),
                SacramentType = await _dataContext.SacramentTypes.FindAsync(model.SacramentTypeId)
            };

            return confirmation;
        }

        public ConfirmationViewModel ToConfirmationViewModel(Confirmation confirmation)
        {
            return new ConfirmationViewModel
            {
                PlaceofEvent = confirmation.PlaceofEvent,
                Id = confirmation.Id,
                FatherName = confirmation.FatherName,
                FatherId = confirmation.FatherId,
                MotherName = confirmation.MotherName,
                MotherId = confirmation.MotherId,
                GodFatherName = confirmation.GodFatherName,
                GodFatherId = confirmation.GodFatherId,
                GodMotherName = confirmation.GodMotherName,
                GodMotherId = confirmation.GodMotherId,
                Comments = confirmation.Comments,
                CeremonialCelebrant = confirmation.CeremonialCelebrant,
                ConfirmationDate = confirmation.ConfirmationDate,
                ParishionerId = confirmation.Parishioner.Id,
                SacramentTypeId = confirmation.SacramentType.Id,
                SacramentTypes = _combosHelper.GetComboSacraments()
            };
        }

        public async Task<Wedding> ToWeddingAsync(WeddingVM model, bool isNew)
        {
            var wedding = new Wedding
            {
                WeedingDate = model.WeedingDate,
                Id = isNew ? 0 : model.Id,
                PlaceOfEvent = model.PlaceOfEvent,
                BrideFatherName = model.BrideFatherName,
                BrideFatherId = model.BrideFatherId,
                BrideMotherName = model.BrideMotherName,
                BrideMotherId = model.BrideMotherId,
                BrideGroomFatherName = model.BrideGroomFatherName,
                BrideGroomFatherId = model.BrideGroomFatherId,
                BrideGroomMotherName = model.BrideGroomMotherName,
                BrideGroomMotherId = model.BrideGroomMotherId,
                GodMother = model.GodMother,
                GodMotherId = model.GodMotherId,
                GodFather = model.GodFather,
                GoFatherId = model.GoFatherId,
                Comments = model.Comments,
                CeremonialCelebrant = model.CeremonialCelebrant,
                Parishioners = await _dataContext.Parishioners.FindAsync(model.ParishionerId),
                SacramentType = await _dataContext.SacramentTypes.FindAsync(model.SacramentTypeId)
            };

            return wedding;
        }

        public WeddingVM ToWeddingVM(Wedding wedding)
        {
            return new WeddingVM
            {
                WeedingDate = wedding.WeedingDate,
                Id = wedding.Id,
                PlaceOfEvent = wedding.PlaceOfEvent,
                Parishioners = wedding.Parishioners,
                BrideFatherName = wedding.BrideFatherName,
                BrideFatherId = wedding.BrideFatherId,
                BrideMotherName = wedding.BrideMotherName,
                BrideMotherId = wedding.BrideMotherId,
                BrideGroomFatherName = wedding.BrideGroomFatherName,
                BrideGroomFatherId = wedding.BrideGroomFatherId,
                BrideGroomMotherName = wedding.BrideGroomMotherName,
                BrideGroomMotherId = wedding.BrideGroomMotherId,
                GodMother = wedding.GodMother,
                GodMotherId = wedding.GodMotherId,
                GodFather = wedding.GodFather,
                GoFatherId = wedding.GoFatherId,
                Comments = wedding.Comments,
                CeremonialCelebrant = wedding.CeremonialCelebrant,
                ParishionerId = wedding.Parishioners.Id,
                SacramentTypeId = wedding.SacramentType.Id,
                SacramentTypes = _combosHelper.GetWedding()
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
      
        public async Task<Request> ToRequestAsync(RequestVM model, bool isNew)
        {
            var request = new Request
            {
                RequestDate = model.RequestDate,
                Id = isNew ? 0 : model.Id,             
                RequestType = await _dataContext.RequestTypes.FindAsync(model.RequestTypeId),
                Parishioner = await _dataContext.Parishioners.FindAsync(model.ParishionerId)
            };

            return request;
        }

        public RequestVM ToRequestVM(Request request)
        {
            return new RequestVM
            {
                RequestDate = request.RequestDate,
                Id = request.Id,
                ParishionerId = request.Parishioner.Id,
                Parishioners = _combosHelper.GetComboParishioners(),
                RequestTypeId = request.RequestType.Id,
                RequestTypes = _combosHelper.GetComboRequestTypes()
            };
        }

        public RequestResponse ToRequestResponse(Request request)
        {
            if (request == null)
            {
                return null;
            }

            return new RequestResponse
            {
                RequestDate = (DateTime)request.RequestDate,
                Id = request.Id,
                RequestType = request.RequestType.Name
            };
        }

        public ParishionerResponse ToParishionerResponse(Parishioner parishioner)
        {
            if (parishioner == null)
            {
                return null;
            }

            return new ParishionerResponse
            {
                FirstName = parishioner.User.FirstName,
                LastName = parishioner.User.LastName,
                Email = parishioner.User.Email,
                Address = parishioner.User.Address,
                PhoneNumber = parishioner.User.PhoneNumber
            };
        }
    }
}