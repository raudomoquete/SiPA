using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Christening : Sacrament
    {
        public int Id { get; set; }

        public Sacrament Sacrament { get; set; }

        [Display(Name = "Nombre del Bautizado")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido del Bautizado")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Fecha del Bautizo")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ChristeningDate { get; set; }

        [Display(Name = "Fecha del Bautizo")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ChristeningDateLocal => ChristeningDate.ToLocalTime();
        public Certificate Certificate { get; set; }
    }
}
