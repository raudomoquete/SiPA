using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class SacramentViewModel
    {
        public int SacramentId { get; set; }
        public int ParishionerId { get; set; }
        
        [Display(Name = "Nombre del Sacramento")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string SacramentName { get; set; }

        [Display(Name = "Fecha del Evento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Lugar del Evento")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string PlaceofEvent { get; set; }

        [Display(Name = "Nombre del Padre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FatherName { get; set; }

        [Display(Name = "Cédula del Padre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FatherId { get; set; }

        [Display(Name = "Nombre de la Madre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string MotherName { get; set; }

        [Display(Name = "Cédula de la Madre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string MotherId { get; set; }

        [Display(Name = "Nombre del Padrino")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodfatherName { get; set; }

        [Display(Name = "Cédula del Padrino")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodfatherId { get; set; }

        [Display(Name = "Nombre de la Madrina")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodmotherName { get; set; }

        [Display(Name = "Cédula de la Madrina")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodmotherId { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string CeremonialCelebrant { get; set; }

        [Display(Name = "Fecha del Evento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateLocal => Date.ToLocalTime();

        public Parishioner Parishioner { get; set; }

        public ICollection<History> Histories { get; set; }


        public DateTime CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateN => CreatedAt.ToLocalTime();


        public DateTime UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]

        public DateTime DateY => UpdatedAt.ToLocalTime();

        public IEnumerable<SelectListItem> SacramentTypes { get; set; }
    }
}
