using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        [Display(Name = "Fecha en que se expide")]
        public DateTime? issuedDate { get; set; }
        public Parishioner Parishioner { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
