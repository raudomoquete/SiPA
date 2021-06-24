using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class FirstCommunion
    {
        public int Id { get; set; }

        public Sacrament Sacrament { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Fecha del Evento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Lugar del evento")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string PlaceofEvent { get; set; }

        [Display(Name = "Nombre del Padre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string FatherName { get; set; }

        [Display(Name = "Cédula del Padre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string FatherId { get; set; }

        [Display(Name = "Nombre de la Madre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string MotherName { get; set; }

        [Display(Name = "Cédula de la Madre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string MotherId { get; set; }

        [Display(Name = "Nombre del Padrino")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodfatherName { get; set; }

        [Display(Name = "Cédula del Padrino")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodfatherId { get; set; }

        [Display(Name = "Nombre de la Madrina")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodmotherName { get; set; }

        [Display(Name = "Cédula de la Madrina")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodmotherId { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CeremonialCelebrant { get; set; }

        public Certificate Certificate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
