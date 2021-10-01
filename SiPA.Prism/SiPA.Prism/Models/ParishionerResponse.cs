﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Prism.Models
{
    public class ParishionerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<RequestResponse> Requests { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
