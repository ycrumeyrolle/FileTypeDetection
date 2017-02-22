using AspNetCore.FileTypeDetection;
using AspNetCore.FileTypeDetection.Pdf;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionBuilderExtensions
    {
        public static IFileTypeDetectionBuilder AddPdf(this IFileTypeDetectionBuilder builder)
        {
            builder.AddBinaryDetector(PdfFileTypes.Pdf);

            return builder;
        }
    }
}