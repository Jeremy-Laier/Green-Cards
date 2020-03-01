using System.Text;
using System.Collections.Generic;
using System.Linq;
using GREEN_CARD.Core.Models;
using CsvHelper;
using System.IO;
using System.Reflection;

namespace GREEN_CARD.Data
{
    public static class GREEN_CARDSeedData
    {
        public static void EnsureSeedData(this GREEN_CARDContext db){
            StreamReader reader = null;
            CsvReader csv = null;
            // try {
            //     reader = new StreamReader("/Users/emiliovazquez/Documents/Spring2020/HackIllinois/Green-Cards/backend/mockdata/mock_user.csv");
            //     csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
            //     // csv.Configuration.HasHeaderRecord = true;
            //     csv.Configuration.HeaderValidated = null;
            //     csv.Configuration.MissingFieldFound = null;
            //     var users = csv.GetRecords<User>().ToList();
            //     foreach(User u in users){
            //         db.Users.Add(u);
            //         db.SaveChanges();
            //     }
            //     db.SaveChanges();
            // }catch{

            // }
            
            // try {
            //     reader = new StreamReader("/Users/emiliovazquez/Documents/Spring2020/HackIllinois/Green-Cards/backend/mockdata/MOCK_DATA.csv");
            //     csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);  
            //     // csv.Configuration.HasHeaderRecord = true;
            //     csv.Configuration.HeaderValidated = null;
            //     csv.Configuration.MissingFieldFound = null;
            //     var transactions = csv.GetRecords<Transaction>().ToList();
            //     foreach(Transaction u in transactions){
            //         db.Transactions.Add(u);
            //         db.SaveChanges();
            //     }
            // }catch{
                
            // }
           
        //    try{
        //         reader = new StreamReader("/Users/emiliovazquez/Documents/Spring2020/HackIllinois/Green-Cards/backend/mockdata/mock_items.csv");
        //         csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
        //         // csv.Configuration.HasHeaderRecord = true;
        //         csv.Configuration.HeaderValidated = null;
        //         csv.Configuration.MissingFieldFound = null;
        //         var items = csv.GetRecords<Item>().ToList();
        //         foreach(Item u in items){
        //             db.Items.Add(u);
        //             db.SaveChanges();
        //         }
        //     }catch{

        //         }
            
        //     try {
        //         reader = new StreamReader("/Users/emiliovazquez/Documents/Spring2020/HackIllinois/Green-Cards/backend/mockdata/mock_receipt.csv");
        //         csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
        //         // csv.Configuration.HasHeaderRecord = true;
        //         csv.Configuration.HeaderValidated = null;
        //         csv.Configuration.MissingFieldFound = null;
        //         var receipts = csv.GetRecords<Receipt>().ToList();
        //         foreach(Receipt u in receipts){
        //             db.Receipts.Add(u);
        //             db.SaveChanges();
        //         }
        //         db.SaveChanges();   
        //          }catch{

        //         }      
        }
         
    }
}
