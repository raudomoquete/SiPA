using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Wedding
    {
        public int Id { get; set; }

        [Display(Name = "Lugar de la Boda")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string PlaceOfEvent { get; set; }

        [Display(Name = "Padre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherName { get; set; }

        [Display(Name = "Cédula del Padre de la Novia")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherId { get; set; }

        [Display(Name = "Madre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherName { get; set; }

        [Display(Name = "Cédula del Padre de la Novia")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherId { get; set; }

        [Display(Name = "Padre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideGroomFatherName { get; set; }

        [Display(Name = "Cédula del Padre del Novio")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideGroomFatherId { get; set; }

        [Display(Name = "Madre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideGroomMotherName { get; set; }

        [Display(Name = "Cédula del Padre del Novio")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideGroomMotherId { get; set; }

        public string BrideAndGroomParents
        {
            get { return BrideFatherName + " " + BrideMotherName + " " + BrideGroomFatherName + " " + BrideGroomMotherName; }
        }

        [Display(Name = "Nombre de la Madrina")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodMother { get; set; }

        [Display(Name = "Cédula de la Madrina")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodMotherId { get; set; }

        [Display(Name = "Nombre del Padrino")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GodFather { get; set; }

        [Display(Name = "Cédula del Padrino")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string GoFatherId { get; set; }

        public string WeedingGodParents
        {
            get { return GodMother + " " + GodFather; }
        }

        [Display(Name = "Fecha de la Boda")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? WeedingDate { get; set; }

        [Display(Name = "Fecha de la Boda")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? WeedingDateLocal => WeedingDate?.ToLocalTime();

        [Display(Name = "Comentarios")]
        [MaxLength(200, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string CeremonialCelebrant { get; set; }

        public SacramentType SacramentType { get; set; }

        public Parishioner Parishioners { get; set; }
    }
}
