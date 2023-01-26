﻿using System;

namespace CapstoneR2.Infrastructure.ViewModel
{
    public class UserViewModel
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public Domain.Models.Enums.Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string ? Password { get; set; }
        
    }
}
