using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Cell Phone")]
        public string PhoneNo { get; set; }

        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

    }
}
