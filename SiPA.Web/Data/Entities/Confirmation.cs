using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Confirmation
    {
        public int Id { get; set; }

        public Sacrament Sacrament { get; set; }

        [Display(Name = "Name of the Confirmed")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Place of event")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string PlaceofEvent { get; set; }

        [Display(Name = "Father Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string FatherName { get; set; }

        [Display(Name = "Father Id")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string FatherId { get; set; }

        [Display(Name = "Mother Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string MotherName { get; set; }

        [Display(Name = "Mother Id")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string MotherId { get; set; }

        [Display(Name = "God Father Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodfatherName { get; set; }

        [Display(Name = "God Father Id")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodfatherId { get; set; }

        [Display(Name = "God Mother Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodmotherName { get; set; }

        [Display(Name = "God Mother Id")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string GodmotherId { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(200, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Comments { get; set; }

        [Display(Name = "Celebrante")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CeremonialCelebrant { get; set; }

        public Certificate Certificate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
