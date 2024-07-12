namespace Biblioteca.Services;


using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;

public class PdfService : IPdfServices
{
    private readonly IConverter _converter;
    private readonly IWebHostEnvironment _env;

    public PdfService(IConverter converter, IWebHostEnvironment env)
    {
        _converter = converter;
        _env = env;
    }

    public byte[] GeneratePdf(string html)
    {

        int startIndex = html.IndexOf("<table");
        int endIndex = html.IndexOf("</table>") + "</table>".Length;
        string tableHtml = html.Substring(startIndex, endIndex - startIndex);
        string htmlToConvert = $"<html><body><h1>Reporte de prestamo</h1><hr/>{tableHtml}</body></html>";
        
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report"
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlToConvert,
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.81 },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };

        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };


        try
        {
            var pdf = _converter.Convert(doc);

            return pdf;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}
