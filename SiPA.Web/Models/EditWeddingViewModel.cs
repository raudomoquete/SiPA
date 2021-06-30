﻿using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Models
{
    public class EditWeddingViewModel : SacramentViewModel
    {
        public int Id { get; set; }

        public Sacrament Sacrament { get; set; }

        [Display(Name = "Nombre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideName { get; set; }
        [Display(Name = "Cédula de la novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideId { get; set; }

        [Display(Name = "Nombre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomName { get; set; }
        [Display(Name = "Cédula del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomId { get; set; }

        [Display(Name = "Novios")]
        public string WeddingGrooms => $"{BrideName} {BridegroomName}";

        [Display(Name = "Fecha de la Boda")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime WeddingDate { get; set; }

        [Display(Name = "Nombre del Padre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherName { get; set; }

        [Display(Name = "Cédula del Padre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideFatherId { get; set; }

        [Display(Name = "Nombre de la  Madre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherName { get; set; }

        [Display(Name = "Cédula de la madre de la Novia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BrideMotherId { get; set; }

        [Display(Name = "Nombre del Padre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomFatherName { get; set; }

        [Display(Name = "Cédula del Padre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomFatherId { get; set; }

        [Display(Name = "Nombre de la  Madre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomMotherName { get; set; }

        [Display(Name = "Cédula de la madre del Novio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        public string BridegroomMotherId { get; set; }

        [Display(Name = "Fecha de la Boda")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime WeddingDateLocal => WeddingDate.ToLocalTime();

        public Certificate Certificate { get; set; }
    }
}