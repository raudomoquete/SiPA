using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class SacramentType
    {
        public int Id { get; set; }

        public int SacramentId { get; set; }

        [Display(Name = "Tipo de Sacramento")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string SacramentName { get; set; }

        public ICollection<Christening> Christenings { get; set; }
    }
}
