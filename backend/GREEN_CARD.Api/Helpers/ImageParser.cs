using System.Collections.Generic;
using GREEN_CARD.Core.Models;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GREEN_CARD.Api.Helpers {
    public static class ImageParser {
        public static string ParseImage(String fileName) { 
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo() {
                UseShellExecute = false,
                CreateNoWindow = false,
                FileName = "python",
                Arguments = "ocr.py --image wwwroot/" + fileName,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            process.Start();
            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            // Write the redirected output to this application's window.
            process.WaitForExit();
            return output;
        }
        public static List<(string, string)> FormatString(string s) {
            List<string> parsed = new List<string>();
            var final = new List<(string, string)>();
            string tmp = "";
            foreach (char c in s) {
                if (c == '?') { parsed.Add(tmp); tmp = ""; }
                else if (c == '(' || c == ')' || c == '\'') {}
                else { tmp = tmp + c.ToString(); }
            }

            foreach (string item in parsed) { var i = item.Split(','); final.Add((i[0], i[1])); }
            return final;
        }
    }
}