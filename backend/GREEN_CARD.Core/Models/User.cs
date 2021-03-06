using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Identity;

namespace GREEN_CARD.Core.Models
{
    public class User {//:IdentityUser{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId{get;set;}
        public String FirstName{get;set;}
        public String LastName{get;set;}
        public double RewardsTotal{get;set;}
        public int AccountNumber{get;set;}
        public double AccountLimit{get;set;}
        public String  Email{get;set;}

    }
}