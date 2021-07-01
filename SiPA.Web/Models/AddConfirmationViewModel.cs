﻿using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class AddConfirmationViewModel : SacramentViewModel
    {

        [Display(Name = "Nombre del Confirmado")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido del Confirmado")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Fecha de la Confirmación")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ConfirmationDate { get; set; }

        public Certificate Certificate { get; set; }


        [Display(Name = "Fecha de la Confirmación")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ConfirmationDateLocal => ConfirmationDate.ToLocalTime();
    }
}
