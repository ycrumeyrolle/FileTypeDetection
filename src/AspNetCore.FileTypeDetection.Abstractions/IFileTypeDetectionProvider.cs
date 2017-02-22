namespace AspNetCore.FileTypeDetection
{
    public interface IFileTypeDetectionProvider
    {
        IFileTypeDetector CreateDetector(string extension);
    }
}