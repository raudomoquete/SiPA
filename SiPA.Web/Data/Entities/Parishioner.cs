using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Parishioner
    {
        public int Id { get; set; }
        public ICollection<Sacrament> Sacraments { get; set; } 
        public ICollection<History> Histories { get; set; }
        public ICollection<RequestType> RequestTypes { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
