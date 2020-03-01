using GREEN_CARD.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Drawing; 
using GREEN_CARD.Api.Helpers;

namespace GREEN_CARD.Api.Controllers {
    
    [Route("api/receipt/")] 
    public class ImageController: Controller {
        public readonly IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment) {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files, int transactionId) {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files) {
                if (formFile.Length > 0) {
                    var filePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot",   
                  formFile.FileName);  

                    ImageParser.ParseImage(formFile.FileName);

                     using (var stream = new FileStream(filePath, FileMode.Create)) {  
                         await formFile.CopyToAsync(stream);  }  
                }
            }
            return Ok(new { count = files.Count, size, transactionId });
        }
    }
}