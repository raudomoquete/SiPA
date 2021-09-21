using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class ChangePasswordVM
    {
        [Display(Name ="Password Actual")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} and {1} caracteres.")]
        public string OldPassword { get; set; }
        [Display(Name = "Nuevo password")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} and {1} caracteres.")]
        public string NewPassword { get; set; }
        [Display(Name = "Confirmar Password")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} and {1} caracteres.")]
        [Compare("NewPassword")]
        public string Confirm { get; set; }
    }
}
