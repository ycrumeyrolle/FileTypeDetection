using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.FileTypeDetection
{
    public static class FileTypeDetectorProviderExtensions
    {
        public static IFileTypeDetector CreateDetector(this IFileTypeDetectionProvider provider, params string[] extensions)
        {
            var providers = new List<IFileTypeDetector>(extensions.Length);
            for (int i = 0; i < extensions.Length; i++)
            {
                providers.Add(provider.CreateDetector(extensions[i]));
            }

            return new CompositeFileTypeDetector(providers);
        }

        private class CompositeFileTypeDetector : IFileTypeDetector
        {
            private readonly IFileTypeDetector[] _providers;

            public CompositeFileTypeDetector(IList<IFileTypeDetector> providers)
            {
                _providers = providers.ToArray();
            }

            public bool CanDetect(string extension)
            {
                for (int i = 0; i < _providers.Length; i++)
                {
                    if (_providers[i].CanDetect(extension))
                    {
                        return true;
                    }
                }

                return false;
            }

            public void Detect(FileTypeDetectionContext context)
            {
                for (int i = 0; i < _providers.Length; i++)
                {
                    _providers[i].Detect(context);
                    if (context.HasSucceeded)
                    {
                        return;
                    }
                }
            }
        }
    }
}
