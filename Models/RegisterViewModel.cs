using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class RegisterViewModel : BaseEntity{
        [Required]
        public string FirstName{get;set;}
        [Required]
        public string LastName{get;set;}
        [Required]
        public string Email{get;set;}
        [Required]
        [MinLength(8, ErrorMessage = "Password be longer than 8 characters long")]
        public string Password{get;set;}
        [Required]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string PWConfirm{get;set;}

    }
}