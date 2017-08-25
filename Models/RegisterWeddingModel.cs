using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class RegisterWeddingModel : BaseEntity{
        [Required]
        public string WedderOne{get;set;}
        [Required]
        public string WedderTwo{get;set;}
        [Required]
        public DateTime Date{get;set;}
        [Required]
        public string WeddingAddress{get;set;}
        public User User{get;set;}
        public List<Guests> Guests{get;set;}
        public RegisterWeddingModel(){
            User = new User();
            Guests = new List<Guests>();
        }
    }
}