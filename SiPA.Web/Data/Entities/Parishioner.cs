using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Parishioner : User
    {
        [Display(Name = "Identification Number")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Identification { get; set; }

        [Display(Name = "Date of Birth")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        [Display(Name = "Civil Status")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CivilStatus { get; set; }

        [Display(Name = "Cell Phone")]
        [MaxLength(13, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CellPhone { get; set; }
        public string Address { get; set; }

        [Display(Name = "have received sacraments ?")]
        public bool ReceivedSacraments { get; set; }
        public ICollection<Sacrament> Sacraments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
