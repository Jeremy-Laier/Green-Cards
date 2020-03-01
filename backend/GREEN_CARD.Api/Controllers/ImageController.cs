using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GREEN_CARD.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GREEN_CARD.Api.Controllers {
    [Route("[/greencard/image]")] 
    public class ImageController: Controller {
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<IFormFile> files) {
            long size = files.Sum(f => f.Length);

            foreach( var formFile in files) {
                if (formFile.Length > 0) {
                    var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath)) {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size});
        }
    }
}