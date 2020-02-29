using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Identity;

namespace GREEN_CARD.Core.Models
{
    public class User :IdentityUser{
        [Key]
        public int UserId{get;set;}
        public double RewardsTotal{get;set;}
        public int AccountNumber{get;set;}
        public double AccountLimit{get;set;}

    }
}