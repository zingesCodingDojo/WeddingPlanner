using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class Wedding : BaseEntity{
        [Key]
        public int WeddingId{get;set;}
        public string WedderOne{get;set;}
        public string WedderTwo{get;set;}
        public DateTime Date{get;set;}
        public string WeddingAddress{get;set;}
        public DateTime WedCreated_At{get;set;}
        public DateTime WedUpdated_At{get;set;}
        public int Userid{get;set;}
        public User User{get;set;}
        public List<Guests> Guests{get;set;}
        public Wedding(){
            Guests = new List<Guests>();
        }
    }
}