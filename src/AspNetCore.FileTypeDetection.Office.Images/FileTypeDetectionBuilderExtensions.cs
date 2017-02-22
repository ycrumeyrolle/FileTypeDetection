using AspNetCore.FileTypeDetection;
using AspNetCore.FileTypeDetection.Images;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionBuilderExtensions
    {
        public static IFileTypeDetectionBuilder AddJpeg(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(ImageFileTypes.Jpg)
                .AddBinaryDetector(ImageFileTypes.Jpg);
        }

        public static IFileTypeDetectionBuilder AddPng(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(ImageFileTypes.Png);
        }

        public static IFileTypeDetectionBuilder AddGif(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(ImageFileTypes.Gif);
        }

        public static IFileTypeDetectionBuilder AddBmp(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(ImageFileTypes.Bmp);
        }

        /// <summary>
        /// Adds common images file types, including .jpeg, .gif and .png.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IFileTypeDetectionBuilder AddCommonImages(this IFileTypeDetectionBuilder builder)
        {
            return builder
                .AddJpeg()
                .AddPng()
                .AddGif();
        }
    }
}