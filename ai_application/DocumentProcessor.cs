using System.Text;
using UglyToad.PdfPig;
using Tesseract;

public static class DocumentProcessor
{
    public static string ExtractTextFromPdf(string filePath)
    {
        var sb = new StringBuilder();

        using (var document = PdfDocument.Open(filePath))
        {
            foreach (var page in document.GetPages())
            {
                sb.AppendLine(page.Text);
            }
        }

        return sb.ToString();
    }

    public static string ExtractTextFromImage(string imagePath)
    {
        string tessDataPath = @"./tessdata"; // Put your tessdata folder here

        using var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default);
        using var img = Pix.LoadFromFile(imagePath);
        using var page = engine.Process(img);
        return page.GetText();
    }
}
