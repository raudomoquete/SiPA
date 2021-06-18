using System;
using System.Collections.Generic;

namespace SiPA.Web.Data.Entities
{
    public class Parishioner
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Sacrament> Sacraments { get; set; } 
        public ICollection<History> Histories { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
