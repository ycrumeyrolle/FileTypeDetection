namespace AspNetCore.FileTypeDetection.Images
{
    public static class ImageFileTypes
    {
        public readonly static FileType Jpeg = new FileType(new byte?[] { 0xFF, 0xD8, 0xFF }, "jpeg", "image/jpeg");
        public readonly static FileType Jpg = new FileType(new byte?[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpeg");
        public readonly static FileType Png = new FileType(new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");
        public readonly static FileType Gif = new FileType(new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, "gif", "image/gif");
        public readonly static FileType Bmp = new FileType(new byte?[] { 66, 77 }, "bmp", "image/gif");
    }
}