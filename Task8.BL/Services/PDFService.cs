﻿using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Font;
using System;
using System.Linq;
using Task8.BL.Interfaces;

namespace Task8.BL
{
    public class PdfService : IPdfService
    {
        private readonly IDocumentHelper<Document> _helper;

        public PdfService(IDocumentHelper<Document> helper)
        {
            _helper = helper;
        }

        public void WriteGroupReport(string savePath, GroupReport report)
        {
            ArgumentNullException.ThrowIfNull(savePath, nameof(savePath));
            ArgumentNullException.ThrowIfNull(report, nameof(report));

            using PdfWriter writer = new(savePath);
            using PdfDocument pdf = new(writer);
            Document document = new(pdf);

            int fontSize = 14;
            int titleFontSize = 16;

            var fontProvider = new FontProvider();
            fontProvider.AddSystemFonts();

            document.SetFont(PdfFontFactory.CreateFont());
            document.SetFontProvider(fontProvider);

            _helper.BuildHeader(document, report.CourseNameHeader, titleFontSize, DocumentFont.TimesNewRoman, true);

            _helper.BuildHeader(document, report.GroupNameHeader, titleFontSize, DocumentFont.TimesNewRoman);

            _helper.BuildStudentList(document, fontSize, DocumentFont.TimesNewRoman, report.Students.ToList());
        }
    }
}
