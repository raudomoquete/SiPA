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

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Identification Number")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Identification { get; set; }

        [Display(Name = "Date of Birth")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }       

        [Display(Name = "Has received any sacrament?")]
        public bool ReceivedSacraments { get; set; }

        [Display(Name = "Civil Status")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CivilStatus { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Cell Phone")]
        public string PhoneNo { get; set; }

        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

    }
}
