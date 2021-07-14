using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiPA.Web.Data.Entities
{
    public class Parishioner
    {
        public int Id { get; set; }

        public User User { get; set; }

        //public int? SacramentId { get; set; }

        //public Sacrament Sacrament { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Sacrament> Sacraments { get; set; }

        public ICollection<Community> Communities { get; set; }

        public ICollection<Certificate> Certificates { get; set; }         

        public ICollection<History> Histories { get; set; }

        public ICollection<Request> Requests { get; set; }

    }
}
