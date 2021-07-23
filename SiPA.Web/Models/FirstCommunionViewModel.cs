using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class FirstCommunionViewModel : FirstCommunion
    {
        public int ParishionerId { get; set; }

        [Display(Name = "Sacramento")]
        public int? SacramentTypeId { get; set; }

        public ICollection<History> Histories { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? CreateDateLocal => CreatedAt?.ToLocalTime();

        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? UpdatedAt { get; set; }

        public DateTime? UpdateDateLocal => UpdatedAt?.ToLocalTime();

        public IEnumerable<SelectListItem> SacramentTypes { get; set; }
    }
}
