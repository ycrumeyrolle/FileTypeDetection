using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.FileTypeDetection
{
    public interface IFileTypeDetectionBuilder
    {
        /// <summary>
        /// Provides access to the <see cref="IServiceCollection"/> passed to this object's constructor.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
