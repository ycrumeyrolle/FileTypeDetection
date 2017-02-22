using System;
using System.IO;
using System.IO.Packaging;

namespace AspNetCore.FileTypeDetection.Office
{
    public class OfficeFileTypeDetector : IFileTypeDetector
    {
        private readonly FileType _fileType;
        private readonly string _mainDocumentContentType;
        private readonly Uri _mainDocumentUri;
        private readonly IFileTypeDetector _zipDetector;

        public OfficeFileTypeDetector(FileType fileType, string mainDocumentUri, string mainDocumentContentType)
        {
            _zipDetector = new BinaryFileTypeDetector(FileTypes.Zip);
            _fileType = fileType;
            _mainDocumentUri = new Uri(mainDocumentUri, UriKind.Relative);
            _mainDocumentContentType = mainDocumentContentType;
        }

        public bool CanDetect(string extension)
        {
            return string.Equals(_fileType.Extension, extension, StringComparison.OrdinalIgnoreCase);
        }

        public void Detect(FileTypeDetectionContext context)
        {
            _zipDetector.Detect(context);
            if (context.HasSucceeded)
            {
                using (Package package = Package.Open(new MemoryStream(context.Data, false), FileMode.Open, FileAccess.Read))
                {
                    if (package.PartExists(_mainDocumentUri))
                    {
                        var part = package.GetPart(_mainDocumentUri);
                        if (string.Equals(part.ContentType, _mainDocumentContentType, StringComparison.OrdinalIgnoreCase))
                        {
                            context.Success(_fileType);
                        }
                        else
                        {
                            context.Skip();
                        }
                    }
                    else
                    {
                        context.Skip();
                    }
                }
            }
        }
    }
}