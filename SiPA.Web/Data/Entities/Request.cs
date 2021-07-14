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

        [Display(Name = "Fecha")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        public Parishioner Parishioner { get; set; }

        public RequestType RequestType { get; set; }
        
        [Display(Name = "Comentario")]
        public string Comment { get; set; }

        [Display(Name = "Está Disponible?")]
        public bool IsAvailable { get; set; }
    }
}
