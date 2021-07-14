using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string GroupName { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public ICollection<Parishioner> Parishioners { get; set; }

        [Display(Name = "Fecha de reuniones")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? MeetingsDate { get; set; }

        [Display(Name = "Actividades")]
        public string Activities { get; set; }

        [Display(Name = "Fecha de reuniones")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? MeetingsDateLocal => MeetingsDate?.ToLocalTime();
    }
}
