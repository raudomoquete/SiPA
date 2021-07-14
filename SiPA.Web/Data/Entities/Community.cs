using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Parishioner> Parishioners { get; set; }
        public DateTime? Meetings { get; set; }
        public string Activities { get; set; }
    }
}
