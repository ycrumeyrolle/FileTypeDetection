using System;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;

namespace AspNetCore.FileTypeDetection.OpenDocument
{
    public class OpenDocumentFileTypeDetector : IFileTypeDetector
    {
        private static readonly Uri mimeTypeUri = new Uri("/mimetype", UriKind.Relative);

        private readonly FileType _fileType;
        private readonly string _mainDocumentContentType;
        private readonly Uri _mainDocumentUri;
        private readonly IFileTypeDetector _zipDetector;

        public OpenDocumentFileTypeDetector(FileType fileType, string mainDocumentContentType)
        {
            _zipDetector = new BinaryFileTypeDetector(FileTypes.Zip);
            _fileType = fileType;
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
                using (var archive = new ZipArchive(new MemoryStream(context.Data, false), ZipArchiveMode.Read))
                {
                    var part = archive.GetEntry("mimetype");
                    using (var stream = part.Open())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var mimeType = reader.ReadToEnd();
                            if (string.Equals(mimeType, _mainDocumentContentType, StringComparison.OrdinalIgnoreCase))
                            {
                                context.Success(_fileType);
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
    }
}