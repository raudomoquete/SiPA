using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboSacraments();

        IEnumerable<SelectListItem> GetChristening();

        IEnumerable<SelectListItem> GetFirstCommunion();

        IEnumerable<SelectListItem> GetConfirmation();

        IEnumerable<SelectListItem> GetComboRequestTypes();

        IEnumerable<SelectListItem> GetComboParishioners();
    }
}
