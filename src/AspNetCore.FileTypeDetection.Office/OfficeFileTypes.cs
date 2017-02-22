namespace AspNetCore.FileTypeDetection.Office
{
    public static class OfficeFileTypes
    {
        public readonly static FileType Docx = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        public readonly static FileType Xlsx = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        public readonly static FileType Xlsb = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "xlsb", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        public readonly static FileType Pptx = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");

        public readonly static FileType Doc = new FileType(new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, "doc", "application/msword", 512);
        public readonly static FileType Xls = new FileType(new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, "xls", "application/excel", 512);
        public readonly static FileType Ppt = new FileType(new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, "ppt", "application/mspowerpoint", 512);
    }
}