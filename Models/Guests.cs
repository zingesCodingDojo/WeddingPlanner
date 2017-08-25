using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models{
    public class Guests : BaseEntity{
        [Key]
        public int GuestId{get;set;}
        public string Action{get;set;}
        // [ForeignKey("GuestId")]
        public int WeddingId{get;set;}

        // [ForeignKey("WeddingId")]
        public Wedding Wedding{get;set;}

        // [ForeignKey("UserId")]
        public int UserId{get;set;}
        public User User{get;set;}
        public DateTime GCreated_At{get;set;}
        public DateTime GUpdated_At{get;set;}

    }
}