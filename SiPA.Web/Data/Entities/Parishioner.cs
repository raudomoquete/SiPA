using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiPA.Web.Data.Entities
{
    public class Parishioner
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<FirstCommunion> FirstCommunions { get; set; }

        public ICollection<Christening> Christenings { get; set; }

        public ICollection<SacramentType> SacramentTypes { get; set; }

        public ICollection<Certificate> Certificates { get; set; }         

        public ICollection<History> Histories { get; set; }

        public ICollection<Request> Requests { get; set; }

    }
}
