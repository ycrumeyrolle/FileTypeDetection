using System;

namespace AspNetCore.FileTypeDetection
{
    public class BinaryFileTypeDetector : IFileTypeDetector
    {
        private readonly FileType _fileType;

        public BinaryFileTypeDetector(FileType fileType)
        {
            _fileType = fileType;
        }

        public bool CanDetect(string extension)
        {
            return string.Equals(_fileType.Extension, extension, StringComparison.OrdinalIgnoreCase);
        }

        public virtual void Detect(FileTypeDetectionContext context)
        {
            for (int i = 0; i < _fileType.Header.Length; i++)
            {
                // if file offset is not set to zero, we need to take this into account when comparing.
                // if byte in type.header is set to null, means this byte is variable, ignore it
                if (_fileType.Header[i] != null && _fileType.Header[i] != context.Data[i + _fileType.HeaderOffset])
                {
                    // if one of the bytes does not match, move on to the next type
                    return;
                }
            }

            context.Success(_fileType);
        }
    }
}