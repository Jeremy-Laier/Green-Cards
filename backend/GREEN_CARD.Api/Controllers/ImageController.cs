using GREEN_CARD.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using GREEN_CARD.Api.Helpers;
using RandomNameGeneratorLibrary;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Controllers {
    [Route("api/receipt/")] 
    public class ImageController: Controller {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IHostingEnvironment _environment;

        public ImageController(IHostingEnvironment environment, IReceiptRepository receiptRepository) {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _receiptRepository = receiptRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files, int transactionId) {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files) {
                if (formFile.Length > 0) {
                    var filePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot",   
                  formFile.FileName);  

                    List<(string, string)> receipts = ImageParser.FormatString(ImageParser.ParseImage(formFile.FileName));


                     using (var stream = new FileStream(filePath, FileMode.Create)) {  
                         await formFile.CopyToAsync(stream);  }  

                    foreach (var item in receipts) {
                        Random random = new Random(DateTime.Now.Second);  
                        var rec = new Receipt();
                        var personGenerator = new PersonNameGenerator();
                        rec.CO2Impact = random.Next();
                        rec.Company = personGenerator.GenerateRandomFirstAndLastName();
                        rec.TransactionId = transactionId;
                        rec.ReceiptCode = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);;
                        rec.ReceiptId = random.Next();

                        await _receiptRepository.Add(rec);
                        // await _db.Receipts.AddAsync(rec);
                        // await _db.SaveChangesAsync();
                    }
                }
            }

            return Ok(new { count = files.Count, size, transactionId });
        }
    }
}