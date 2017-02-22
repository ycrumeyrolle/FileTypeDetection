namespace AspNetCore.FileTypeDetection
{
    public static class FileTypes
    {
        public readonly static FileType Zip = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "zip", "application/x-compressed");
    }
}