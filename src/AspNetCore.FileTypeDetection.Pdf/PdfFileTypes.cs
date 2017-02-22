namespace AspNetCore.FileTypeDetection.Pdf
{
    public static class PdfFileTypes
    {
        public readonly static FileType Pdf = new FileType(new byte?[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");
    }
}