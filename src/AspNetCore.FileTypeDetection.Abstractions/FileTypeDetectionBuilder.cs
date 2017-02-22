using System;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.FileTypeDetection
{
    public class FileTypeDetectionBuilder : IFileTypeDetectionBuilder
    {
        public FileTypeDetectionBuilder(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Services = services;
        }

        /// <inheritdoc />
        public IServiceCollection Services { get; }
    }
}
