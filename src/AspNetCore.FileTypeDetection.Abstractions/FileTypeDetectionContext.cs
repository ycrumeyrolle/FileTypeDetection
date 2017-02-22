using System.Collections.Generic;

namespace AspNetCore.FileTypeDetection
{
    public class FileTypeDetectionContext
    {
        private bool _succeeded;

        public FileTypeDetectionContext(byte[] data)
        {
            Data = data;
        }

        public byte[] Data { get; }

        public bool HasSucceeded
        {
            get
            {
                return _succeeded;
            }
        }

        public FileType FileType { get; private set; }

        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();

        public void Success(FileType fileType)
        {
            _succeeded = true;
            FileType = fileType;
        }

        public void Skip()
        {
            _succeeded = false;
            FileType = null;
        }
    }
}