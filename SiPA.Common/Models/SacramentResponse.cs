using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class SacramentResponse
    {
        public int Id { get; set; }
        public string SacramentType { get; set; }
        public ICollection<HistoryResponse> Histories { get; set; }
        public ChristeningResponse Christening { get; set; }
        public FirstCommunionResponse FirstCommunion { get; set; }
        public ConfirmationResponse Confirmation { get; set; }
        public WeddingResponse Wedding { get; set; }
    }
}
