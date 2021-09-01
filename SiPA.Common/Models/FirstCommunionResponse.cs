using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class FirstCommunionResponse
    {
        public int Id { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Comments { get; set; }
        public string CeremonialCelebrant { get; set; }
        public DateTime? FirstCommunionDate { get; set; }
    }
}
