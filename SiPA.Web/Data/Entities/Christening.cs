using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Christening
    {
        public int Id { get; set; }

        [Display(Name = "Lugar del Bautizo")]
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

        [Display(Name = "Padres del Bautizado")]
        public string BaptizedParents
        {
            get { return FatherName + " " + MotherName; }

            set { FatherName = value; MotherName = value; }
        }

        [Display(Name = "Nombre del Padrino")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodFatherName { get; set; }

        [Display(Name = "Cédula del Padrino")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodFatherId { get; set; }

        [Display(Name = "Nombre de la Madrina")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodMotherName { get; set; }

        [Display(Name = "Cédula de la Madrina")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodMotherId { get; set; }

        [Display(Name = "Padrinos del Bautizado")]
        public string BaptizedGodParents
        {
            get
            {
                return GodFatherName + " " + GodMotherName;
            }
            set
            {
                GodFatherName = value;
                GodMotherName = value;
            }
        }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string CeremonialCelebrant { get; set; }


        [Display(Name = "Fecha del Bautizo")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ChristeningDate { get; set; }


        [Display(Name = "Fecha del Bautizo")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? ChristeningDateLocal => ChristeningDate?.ToLocalTime();

        public SacramentType SacramentType { get; set; }

        public Parishioner Parishioner { get; set; }
    }
}
