using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GREEN_CARD.Core.Models
{
    public class Item{
        [Key]
        public int ItemId{get;set;}
        [ForeignKey("Receipt")]
        [Column(Order = 1)]
        public int ReceiptId{get;set;}
        public String ProductCategory{get;set;}
        public double CO2Impact {get;set;}
        public double Price {get;set;}
        public int QRCode {get;set;}

    }

}