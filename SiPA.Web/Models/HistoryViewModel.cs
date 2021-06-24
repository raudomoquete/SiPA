using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class HistoryViewModel : History
    {
        public int SacramentId { get; set; }

        public int ParishionerId { get; set; }

        [Required]
        [Display(Name = "Tipo de Requerimiento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de Requerimiento")]
        public int RequestTypeId { get; set; }

        public IEnumerable<SelectListItem> RequestTypes { get; set; }
    }
}
