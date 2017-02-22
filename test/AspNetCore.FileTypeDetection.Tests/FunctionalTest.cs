using System.Collections.Generic;
using System.IO;
using AspNetCore.FileTypeDetection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AF.Security.MimeDetection.Tests
{
    public class FunctionalTest
    {
        [Theory]
        [MemberData(nameof(GetValidDocuments))]
        public void DetectValidFileType_ReturnsTrue(byte[] data, string extension, string expectedContentType)
        {
            var detector = CreateDetector(extension);
            var ctx = new FileTypeDetectionContext(data);
            detector.Detect(ctx);

            Assert.True(ctx.HasSucceeded);
        }

        [Theory]
        [MemberData(nameof(GetInvalidDocuments))]
        public void DetectInvalidFileType_ReturnsFalse(byte[] data, string extension, string expectedContentType)
        {
            var detector = CreateDetector(extension);
            var ctx = new FileTypeDetectionContext(data);
            detector.Detect(ctx);

            Assert.False(ctx.HasSucceeded);
        }

        public static IEnumerable<object[]> GetValidDocuments()
        {
            yield return new object[] { GetFile("word.docx"), "docx", "" };
            yield return new object[] { GetFile("word.doc"), "doc", "" };
            yield return new object[] { GetFile("OpenDocument.odt"), "odt", "" };

            yield return new object[] { GetFile("excel.xlsx"), "xlsx", "" };
            yield return new object[] { GetFile("excel.xls"), "xls", "" };
            yield return new object[] { GetFile("excel.xlsb"), "xlsb", "" };
            yield return new object[] { GetFile("OpenDocument.ods"), "ods", "" };
            
            yield return new object[] { GetFile("powerpoint.pptx"), "pptx", "" };
            yield return new object[] { GetFile("powerpoint.ppt"), "ppt", "" };
            yield return new object[] { GetFile("OpenDocument.odp"), "odp", "" };

            yield return new object[] { GetFile("acrobat.pdf"), "pdf", "" };
        }

        public static IEnumerable<object[]> GetInvalidDocuments()
        {
            yield return new object[] { GetFile("word.docx"), "doc", "" };
        }

        private static byte[] GetFile(string filename)
        {
            return File.ReadAllBytes("files/" + filename);
        }

        private static IFileTypeDetector CreateDetector(string extension)
        {
            var services = new ServiceCollection();

            services.AddFileTypeDetection()
                .AddOpenOfficeXml()
                .AddLegacyOffice()
                .AddXlsb()
                .AddZip()
                .AddPdf()
                .AddOpenDocument();

            var sp = services.BuildServiceProvider();

            var provider = sp.GetService<IFileTypeDetectionProvider>();

            return provider.CreateDetector(extension);
        }
    }
}
