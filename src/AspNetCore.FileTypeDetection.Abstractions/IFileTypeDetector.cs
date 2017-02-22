namespace AspNetCore.FileTypeDetection
{
    public interface IFileTypeDetector
    {
        bool CanDetect(string extension);

        void Detect(FileTypeDetectionContext context);
    }
}