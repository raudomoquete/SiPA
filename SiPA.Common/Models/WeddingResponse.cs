using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class WeddingResponse
    {
        public int Id { get; set; }
        public string BrideFatherName { get; set; }
        public string BrideMotherName { get; set; }
        public string BrideGroomFatherName { get; set; }
        public string BrideGroomMotherName { get; set; }
        public string GodMother { get; set; }
        public string GodFather { get; set; }
        public string Comments { get; set; }
        public string CeremonialCelebrant { get; set; }
        public DateTime? WeedingDate { get; set; }
    }
}
