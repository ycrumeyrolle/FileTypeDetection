using AspNetCore.FileTypeDetection;
using AspNetCore.FileTypeDetection.Office;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileTypeDetectionBuilderExtensions
    {
        public static IFileTypeDetectionBuilder AddDocx(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOoxmlFileType(OfficeFileTypes.Docx, "/word/document.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml");
        }

        public static IFileTypeDetectionBuilder AddXlsx(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOoxmlFileType(OfficeFileTypes.Xlsx, "/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
        }

        public static IFileTypeDetectionBuilder AddXlsb(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOoxmlFileType(OfficeFileTypes.Xlsb, "/xl/workbook.bin", "application/vnd.ms-excel.sheet.binary.macroEnabled.main");
        }

        public static IFileTypeDetectionBuilder AddPptx(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddOoxmlFileType(OfficeFileTypes.Pptx, "/ppt/presentation.xml", "application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml");
        }

        public static IFileTypeDetectionBuilder AddDoc(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(OfficeFileTypes.Doc);
        }

        public static IFileTypeDetectionBuilder AddXls(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(OfficeFileTypes.Xls);
        }

        public static IFileTypeDetectionBuilder AddPpt(this IFileTypeDetectionBuilder builder)
        {
            return builder.AddBinaryDetector(OfficeFileTypes.Ppt);
        }

        /// <summary>
        /// Adds Open Office XML file types, including doc, xls and ppt.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IFileTypeDetectionBuilder AddOpenOfficeXml(this IFileTypeDetectionBuilder builder)
        {
            return builder
                .AddDocx()
                .AddXlsx()
                .AddPptx();
        }

        /// <summary>
        /// Adds legacy Office file types, including .doc, .xls and .ppt.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IFileTypeDetectionBuilder AddLegacyOffice(this IFileTypeDetectionBuilder builder)
        {
            return builder
                .AddDoc()
                .AddXls()
                .AddPpt();
        }

        private static IFileTypeDetectionBuilder AddOoxmlFileType(this IFileTypeDetectionBuilder builder, FileType fileType, string mainDocumentUri, string mainDocumentContentType)
        {
           return builder.AddDetector(new OfficeFileTypeDetector(fileType, mainDocumentUri, mainDocumentContentType));
        }
    }
}