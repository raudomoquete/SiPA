using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [Display(Name = "Cédula del Solicitante")]
        [Required(ErrorMessage = "Debe digitar {0}")]
        [StringLength(13, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 13)]
        public string Identification { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe digitar {0}")]
        public string Email { get; set; }

        [Display(Name = "Fecha de la Solicitud")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Fecha de Impresión")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PrintingDate { get; set; }

        [Display(Name = "Impreso por:")]
        public string PrintedBy { get; set; }

        [Display(Name = "Fecha de Envío")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Enviado por:")]
        public string SentBy { get; set; }

        //public int CertificateId { get; set; }

        [Display(Name = "Terminada?")]
        public bool Finished { get; set; }

        [Display(Name = "Terminada por:")]
        public string FinishedBy { get; set; }

        public CertificatesTypes CertificatesTypes { get; set; }

        public RequestType RequestType { get; set; }

        [Display(Name = "Feligrés")]
        public Parishioner Parishioner { get; set; }

        public ICollection<History> Histories { get; set; }
    }
}
