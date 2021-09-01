using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class RequestType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
