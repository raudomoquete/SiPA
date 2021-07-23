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

        [Display(Name = "Fecha de la Primera Comunión")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? FirstCommunionDate { get; set; }

        [Display(Name = "Fecha del Comunión")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? FirstCommunionDateLocal => FirstCommunionDate?.ToLocalTime();

        [Display(Name = "Lugar del Evento")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string PlaceofEvent { get; set; }

        [Display(Name = "Nombre del Padre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FatherName { get; set; }

        [Display(Name = "Cédula del Padre")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FatherId { get; set; }

        [Display(Name = "Nombre de la Madre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string MotherName { get; set; }

        [Display(Name = "Cédula de la Madre")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string MotherId { get; set; }

        [Display(Name = "Padres del Feligrés")]
        public string ParishionerParents
        {
            get { return FatherName + " " + MotherName; }

            set { FatherName = value; MotherName = value; }
        }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string CeremonialCelebrant { get; set; }

        public Parishioner Parishioner { get; set; }
        public SacramentType SacramentType { get; set; }

    }
}
