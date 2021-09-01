using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class ParishionerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ChristeningResponse Christening { get; set; }
        public FirstCommunionResponse FirstCommunion { get; set; }
        public ConfirmationResponse Confirmation { get; set; }
        public WeddingResponse Wedding { get; set; }
        public ICollection<SacramentResponse> Sacraments { get; set; }
        public ICollection<RequestResponse> Requests { get; set; }
    }
}
