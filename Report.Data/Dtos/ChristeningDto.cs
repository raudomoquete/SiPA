using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Dtos
{
    public class ChristeningDto
    {
        public int Id { get; set; }
        public string PlaceofEvent { get; set; }
        public string CeremonialCelebrant { get; set; }
        public DateTime? ChristeningDate { get; set; }
    }
}
