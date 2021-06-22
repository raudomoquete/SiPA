using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Sacrament
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Sacramento")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Parishioner Parishioner { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
