using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GREEN_CARD.Core.Models
{
    public class Receipt{
        [Key]
        public int ReceiptId{get;set;}
        [ForeignKey("Transaction")]
        [Column(Order = 1)]
        public int TransactionId{get;set;}
        public String ReceiptCode{get;set;}
        public double Rewards{get;set;}
        public String Company{get;set;}
        public double CO2Impact{get;set;}
    }
}