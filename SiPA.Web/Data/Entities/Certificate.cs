using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public int SacramentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
