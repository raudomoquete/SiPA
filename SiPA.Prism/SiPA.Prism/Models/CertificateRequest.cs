using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiPA.Prism.Models
{
    public class CertificateRequest
    {
        public int Id { get; set; }

        public DateTime? RequestDate { get; set; }

        public int RequestTypeId { get; set; }

        public int ParishionerId { get; set; }
    }
}
