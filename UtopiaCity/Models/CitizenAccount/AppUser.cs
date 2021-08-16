using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Extended class by IdentityUser, represent User of App.
    /// </summary>
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public double Balance { get; set; }
    }
}
