using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data.Entities
{
    public class Sacrament 
    {
        public int Id { get; set; }

        public Christening Christening { get; set; }

        //[Display(Name = "Nombre de la Novia")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideFirstName { get; set; }

        //[Display(Name = "Apellido de la Novia")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideLastName { get; set; }

        //public string BrideFullName
        //{
        //    get
        //    {
        //        return BrideFirstName + " " + BrideLastName;
        //    }
        //    set
        //    {
        //        BrideFirstName = value;
        //        BrideLastName = value;
        //    }
        //}

        //[Display(Name = "Cédula de la novia")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideId { get; set; }

        //[Display(Name = "Nombre del Novio")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomFirstName { get; set; }

        //[Display(Name = "Apellido del novio")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomLastName { get; set; }

        //public string BridegroomFullName
        //{
        //    get
        //    {
        //        return BridegroomFirstName + " " + BridegroomLastName;
        //    }

        //    set
        //    {
        //        BridegroomFirstName = value;
        //        BridegroomLastName = value;
        //    }
        //}

        //[Display(Name = "Cédula del Novio")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomId { get; set; }

        //[Display(Name = "Novios")]
        //public string WeddingGrooms
        //{
        //    get
        //    {
        //        return BrideFullName + " " + BridegroomFullName;
        //    }

        //    set
        //    {
        //        BrideFullName = value;
        //        BridegroomFullName = value;
        //    }
        //}

        //[Display(Name = "Nombre del Padre de la Novia")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideFatherName { get; set; }

        //[Display(Name = "Cédula del Padre de la Novia")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideFatherId { get; set; }

        //[Display(Name = "Nombre de la  Madre de la Novia")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideMotherName { get; set; }

        //[Display(Name = "Cédula de la madre de la Novia")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BrideMotherId { get; set; }

        //public string WeddingBrideParents
        //{
        //    get
        //    {
        //        return BrideFatherName + " " + BrideMotherName;
        //    }

        //    set
        //    {
        //        BrideFatherName = value;
        //        BrideMotherName = value;
        //    }
        //}

        //[Display(Name = "Nombre del Padre del Novio")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomFatherName { get; set; }

        //[Display(Name = "Cédula del Padre del Novio")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomFatherId { get; set; }

        //[Display(Name = "Nombre de la  Madre del Novio")]
        //[MaxLength(50, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomMotherName { get; set; }

        //[Display(Name = "Cédula de la madre del Novio")]
        //[MaxLength(13, ErrorMessage = "El {0} campo no puede tener mas de {1} caracteres.")]
        //public string BridegroomMotherId { get; set; }

        //public string WeddingBridegroomParents
        //{
        //    get
        //    {
        //        return BridegroomFatherName + " " + BridegroomMotherName;
        //    }

        //    set
        //    {
        //        BridegroomFatherName = value;
        //        BridegroomMotherName = value;
        //    }
        //}

        //public string WeddingGodParents
        //{
        //    get
        //    {
        //        return GodFatherName + " " + GodMotherName;
        //    }
        //    set
        //    {
        //        GodFatherName = value;
        //        GodMotherName = value;
        //    }
        //}

        public Parishioner Parishioner { get; set; }

        public SacramentType SacramentType { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
    }
}

