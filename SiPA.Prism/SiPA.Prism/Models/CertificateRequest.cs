using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiPA.Prism.Models
{
    public class CertificateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de la Solicitud")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Fecha de la Solicitud")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? RequestDateLocal => RequestDate?.ToLocalTime();

        [Display(Name = "Tipo de Solicitud")]
        public int RequestTypeId { get; set; }

        public int ParishionerId { get; set; }
    }
}
