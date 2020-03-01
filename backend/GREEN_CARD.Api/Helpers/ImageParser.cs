using System.Collections.Generic;
using GREEN_CARD.Core.Models;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GREEN_CARD.Api.Helpers {
    public class ImageParser {
        public void ParseImag21Ze(String fileName) { 
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo() {
                UseShellExecute = false,
                CreateNoWindow = false,
                FileName = "python",
                Arguments = "ocr.py --image " + fileName,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            process.Start();
            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            // Write the redirected output to this application's window.
            Console.WriteLine(output);

            process.WaitForExit();
        }
    }
}