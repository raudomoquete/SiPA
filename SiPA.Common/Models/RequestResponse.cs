using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class RequestResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestTypes { get; set; }
        public ICollection<HistoryResponse> Histories { get; set; }
    }
}
