 
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using CliWrap;

namespace GREEN_CARD.Api {
    public class Program {
        public static void Main(string[] args) {
            
        var result = Cli.Wrap("/usr/bin/python3.8")
        .WithArguments("../python/ocr.py --image ../NHLStats.Api/sample-receipt3.jpg")
        .ExecuteAsync();
        
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo = new System.Diagnostics.ProcessStartInfo() {
            UseShellExecute = false,
            CreateNoWindow = false,
            FileName = "python",
            Arguments = "ocr.py --image sample-receipt1.jpg",
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

        // BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000/")
                .Build();
    }
}
