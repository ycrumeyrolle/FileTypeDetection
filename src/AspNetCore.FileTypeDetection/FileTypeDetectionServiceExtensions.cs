using System;
using AspNetCore.FileTypeDetection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionServiceExtensions
    {
        public static IFileTypeDetectionBuilder AddFileTypeDetection(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // services.AddOptions();
            services.AddSingleton<IFileTypeDetectionProvider, FileTypeDetectorProvider>();

            return new FileTypeDetectionBuilder(services);
        }
    }
}
