namespace AspNetCore.FileTypeDetection.OpenDocument
{
    public static class OpenDocumentFileTypes
    {
        public readonly static FileType Odt = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "odt", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        public readonly static FileType Ods = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "ods", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        public readonly static FileType Odp = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "odp", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
    }
}