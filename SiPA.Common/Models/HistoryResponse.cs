using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class HistoryResponse
    {
        public int Id { get; set; }
        public string RequestType { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
