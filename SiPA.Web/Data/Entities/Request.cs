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

        [Display(Name = "Fecha de la Solicitud")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Fecha de la Solicitud")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? RequestDateLocal => RequestDate?.ToLocalTime();

        [Display(Name = "Tipo de Solicitud")]
        public RequestType RequestType { get; set; }

        [Display(Name = "Solicitante")]
        public Parishioner Parishioner { get; set; }
    }
}
