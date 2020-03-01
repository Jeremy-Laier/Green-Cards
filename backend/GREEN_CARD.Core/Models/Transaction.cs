using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Identity;

namespace GREEN_CARD.Core.Models
{
    public class Transaction{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId{get;set;}
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId{get;set;}
        public DateTime Date{get;set;}
        public String Location{get;set;}
        public double Amount{get;set;}
        public bool HaveReceipt {get;set;}
    }
}