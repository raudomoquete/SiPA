using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class ChristeningViewModel : Christening
    {
        public int ParishionerId { get; set; }

        public int? SacramentId { get; set; }

        public int? SacramentTypeId { get; set; }

        public ICollection<History> Histories { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? CreateDateLocal => CreatedAt?.ToLocalTime();

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? UpdatedAt { get; set; }

        public DateTime? UpdateDateLocal => UpdatedAt?.ToLocalTime();

        public IEnumerable<SelectListItem> SacramentTypes { get; set; }
    }
}
