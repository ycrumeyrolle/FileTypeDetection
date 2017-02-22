using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.FileTypeDetection
{
    public class FileTypeDetectorProvider : IFileTypeDetectionProvider
    {
        private readonly IFileTypeDetector[] _detectors;

        public FileTypeDetectorProvider(IEnumerable<IFileTypeDetector> detectors)
        {
            _detectors = detectors.ToArray();
        }

        public IFileTypeDetector CreateDetector(string extension)
        {
            for (int i = 0; i < _detectors.Length; i++)
            {
                if (_detectors[i].CanDetect(extension))
                {
                    return _detectors[i];
                }
            }

            throw new InvalidOperationException($"Unable to find a detector for {extension}");
        }
    }
}