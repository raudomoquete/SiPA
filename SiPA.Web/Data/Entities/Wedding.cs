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

        public Sacrament Sacrament { get; set; }

        [Display(Name = "Nombre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideName { get; set; }
        [Display(Name = "Cédula de la novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideId { get; set; }

        [Display(Name = "Nombre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomName { get; set; }
        [Display(Name = "Cédula del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomId { get; set; }

        [Display(Name = "Novios")]
        public string WeddingGrooms => $"{BrideName} {BridegroomName}";

        [Display(Name = "Fecha de la Boda")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Lugar del Evento")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string PlaceofEvent { get; set; }

        [Display(Name = "Nombre del Padre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherName { get; set; }

        [Display(Name = "Cédula del Padre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherId { get; set; }

        [Display(Name = "Nombre de la  Madre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherName { get; set; }

        [Display(Name = "Cédula de la madre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherId { get; set; }

        [Display(Name = "Nombre del Padre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomFatherName { get; set; }

        [Display(Name = "Cédula del Padre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomFatherId { get; set; }

        [Display(Name = "Nombre de la  Madre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomMotherName { get; set; }

        [Display(Name = "Cédula de la madre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomMotherId { get; set; }

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

        public Certificate Certificate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
