using AspNetCore.FileTypeDetection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionBuilderExtensions
    {
        public static IFileTypeDetectionBuilder AddDetector(this IFileTypeDetectionBuilder builder, IFileTypeDetector detector)
        {
            builder.Services.AddSingleton(detector);

            return builder;
        }

        public static IFileTypeDetectionBuilder AddBinaryDetector(this IFileTypeDetectionBuilder builder, FileType fileType)
        {
            return builder.AddDetector(new BinaryFileTypeDetector(fileType));
        }

        public static IFileTypeDetectionBuilder AddZip(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(FileTypes.Zip);
        }
    }
}