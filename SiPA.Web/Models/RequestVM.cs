using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class RequestVM : Request
    {
        [Display(Name = "Solicitante")]
        public int ParishionerId { get; set; }
        public IEnumerable<SelectListItem> Parishioners { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        public int RequestTypeId { get; set; }
        public IEnumerable<SelectListItem> RequestTypes { get; set; }
    }
}
