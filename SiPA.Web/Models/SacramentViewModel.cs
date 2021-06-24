using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class SacramentViewModel : Sacrament
    {
        public int ParishionerId { get; set; }

        [Required(ErrorMessage ="El campo {0} es Obligatorio")]
        [Display(Name = "Sacramento")]
        public int SacramentId { get; set; }

        public IEnumerable<SelectListItem> Sacraments { get; set; }
    }
}
