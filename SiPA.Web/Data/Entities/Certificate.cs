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

        [Display(Name = "Nombre")]
        public string Tipo { get; set; }

        [Display(Name = "Feligrés")]
        public Parishioner Parishioner { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        [Display(Name = "Fecha en que se expide")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? issuedDate { get; set; }

        public CertificatesTypes CertificatesTypes { get; set; }
    }
}
