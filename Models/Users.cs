using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models{
    public abstract class BaseEntity{}
    public class User : BaseEntity{
        [Key]
        public int UserId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public DateTime UserCreated_At{get;set;}
        public DateTime UserUpdated_At{get;set;}


        public List<Wedding> Wedding{get;set;}
        // [ForeignKey("UserId")]s
        public List<Guests> Guests{get;set;}
        public User(){
            Wedding = new List<Wedding>();
            Guests = new List<Guests>();

        }

    }
}