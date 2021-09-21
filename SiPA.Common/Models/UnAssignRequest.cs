using System.ComponentModel.DataAnnotations;

namespace SiPA.Common.Models
{
    public class UnAssignRequest
    {
        [Required]
        public int RequestId { get; set; }
    }
}
