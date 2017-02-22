using AspNetCore.FileTypeDetection;
using AspNetCore.FileTypeDetection.OpenDocument;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionBuilderExtensions
    {
        public static IFileTypeDetectionBuilder AddOdt(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOpenDocumentFileType(OpenDocumentFileTypes.Odt, "application/vnd.oasis.opendocument.text");
        }

        public static IFileTypeDetectionBuilder AddOds(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOpenDocumentFileType(OpenDocumentFileTypes.Ods, "application/vnd.oasis.opendocument.spreadsheet");
        }

        public static IFileTypeDetectionBuilder AddOdp(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOpenDocumentFileType(OpenDocumentFileTypes.Odp, "application/vnd.oasis.opendocument.presentation");
        }

        /// <summary>
        /// Adds Open Document file types, including .odt, .ods and .odp.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IFileTypeDetectionBuilder AddOpenDocument(this IFileTypeDetectionBuilder builder)
        {
            return builder
                .AddOdp()
                .AddOds()
                .AddOdt();
        }

        private static IFileTypeDetectionBuilder AddOpenDocumentFileType(this IFileTypeDetectionBuilder builder, FileType fileType, string mimeType)
        {
            return builder.AddDetector(new OpenDocumentFileTypeDetector(fileType, mimeType));
        }
    }
}