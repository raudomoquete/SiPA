using System;

namespace SiPA.Prism.Models
{
    public class RequestResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestType { get; set; }
    }
}
