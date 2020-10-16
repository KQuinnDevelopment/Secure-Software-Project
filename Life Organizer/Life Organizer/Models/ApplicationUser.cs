using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Organizer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Text), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text), Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}