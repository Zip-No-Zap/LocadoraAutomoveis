using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace GeradorTestes.Infra.Arquivo.Compartilhado
{
    public class GeradorPdf
    {

        //public void GerarPDF_Sharp(string texto)
        //{
        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //    using (var doc = new PdfSharp.Pdf.PdfDocument())
        //    {
        //        var page = doc.AddPage();
        //        var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
        //        var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
        //        var font = new PdfSharp.Drawing.XFont("Arial", 14);

        //        textFormatter.DrawString(texto, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(0, 0, page.Width, page.Height));

        //        doc.Save("Teste.pdf");
        //        //System.Diagnostics.Process.Start("Teste.pdf");
        //    }
        //}

        public void GerarPDF_ItextSharp(string texto, string cliente)
        {
            string nomeArquivo = @"C:\temp\pdf\Comprovante_"+cliente+@"_"+DateTime.Now.Second+@".pdf";
            FileStream arquivoPDF = new(nomeArquivo, FileMode.Create);
            iTextSharp.text.Document doc = new(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo = new(dados, new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("LOCADORA DE AUTOMÓVEIS 1.0\n\n");

            paragrafo.Font = new Font(Font.NORMAL, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo.Add(texto + "\n");

            //Image imagem = Image.GetInstance(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\projeto Locadora\imagens carros\Lobini h1 preto.jpg");
            //imagem.ScalePercent(30);
            //doc.Add(imagem);

            doc.Open();
            doc.Add(paragrafo);//doc.Add(imagem)
            doc.Close();
        }
    }
}
