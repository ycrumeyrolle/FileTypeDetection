using System;
using System.IO;
using AspNetCore.FileTypeDetection;
using Microsoft.Extensions.DependencyInjection;

namespace FileTypeDetectionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddFileTypeDetection()
                .AddDocx()
                .AddDoc()
                .AddXlsx()
                .AddZip();

            var sp = services.BuildServiceProvider();

            var provider = sp.GetService<IFileTypeDetectionProvider>();

            var detector = provider.CreateDetector("doc", "docx", "xlsx", "pdf");

            var data = File.ReadAllBytes("word.doc");
            var ctx = new FileTypeDetectionContext(data);

            detector.Detect(ctx);
            Console.WriteLine(ctx.HasSucceeded);
        }
    }
}
