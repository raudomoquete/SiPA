using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiPA.Web.Data.Entities
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Nombre del Feligrés")]
        public string ParishionerFullName
        {
            get { return FirstName + " " + LastName; }

            set
            {
                FirstName = value;
                LastName = value;
            }
        }

        [Display(Name = "Cédula")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Identification { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Nacionalidad")]
        public string Nationality { get; set; }
        
        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Estado Civil")]
        [MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string CivilStatus { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Request> Requests { get; set; }

    }
}
