using System.ComponentModel.DataAnnotations;

namespace SiPA.Prism.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
