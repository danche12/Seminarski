using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace KlijentskaAplikacija.Servisi.Pdf
{
    public class PdfGenerator
    {
        private string _sadrzaj;
        private string _naslov;
        private string _putanja;

        public byte[] GenerisiRasporedCasovaUBajtovima(string naslov, string sadrzaj)
        {
            try
            {
                // Generiši jednostavan PDF sa osnovnim sadržajem
                _naslov = naslov;
                _sadrzaj = sadrzaj;
                
                // Kreiraj jednostavan PDF sadržaj
                string[] linije = sadrzaj.Split('\n');
                string pdfSadrzaj = $@"%PDF-1.4
                    1 0 obj
                    <<
                    /Type /Catalog
                    /Pages 2 0 R
                    >>
                    endobj

                    2 0 obj
                    <<
                    /Type /Pages
                    /Kids [3 0 R]
                    /Count 1
                    >>
                    endobj

                    3 0 obj
                    <<
                    /Type /Page
                    /Parent 2 0 R
                    /MediaBox [0 0 612 792]
                    /Contents 4 0 R
                    /Resources <<
                    /Font <<
                    /F1 <<
                    /Type /Font
                    /Subtype /Type1
                    /BaseFont /Helvetica
                    >>
                    /F2 <<
                    /Type /Font
                    /Subtype /Type1
                    /BaseFont /Helvetica
                    >>
                    /F3 <<
                    /Type /Font
                    /Subtype /Type1
                    /BaseFont /Helvetica-Bold
                    >>
                    >>
                    >>
                    >>
                    endobj

                    4 0 obj
                    <<
                    /Length 200
                    >>
                    stream
                    BT
                    /F2 16 Tf
                    50 750 Td
                    ({naslov?.Replace("Č", "C").Replace("Ć", "C").Replace("Đ", "D").Replace("Š", "S").Replace("Ž", "Z").Replace("č", "c").Replace("ć", "c").Replace("đ", "d").Replace("š", "s").Replace("ž", "z")}) Tj
                    0 -30 Td
                    /F2 12 Tf
                    ";

                foreach (string linija in linije)
                {
                    if (!string.IsNullOrWhiteSpace(linija))
                    {
                        // Proveri da li linija sadrži bold marker
                        if (linija.Contains("**"))
                        {
                            // Boldovanje - ukloni markere i koristi bold font
                            string boldText = linija.Replace("**", "");
                            string cleanLine = boldText
                                .Replace("Č", "C")
                                .Replace("Ć", "C")
                                .Replace("Đ", "D")
                                .Replace("Š", "S")
                                .Replace("Ž", "Z")
                                .Replace("č", "c")
                                .Replace("ć", "c")
                                .Replace("đ", "d")
                                .Replace("š", "s")
                                .Replace("ž", "z")
                                .Replace("\\", "\\\\")
                                .Replace("(", "\\(")
                                .Replace(")", "\\)")
                                .Replace("[", "\\[")
                                .Replace("]", "\\]");
                            pdfSadrzaj += $"/F3 12 Tf ({cleanLine}) Tj 0 -15 Td\n";
                        }
                        else
                        {
                            // Običan tekst
                            string cleanLine = linija
                                .Replace("Č", "C")
                                .Replace("Ć", "C")
                                .Replace("Đ", "D")
                                .Replace("Š", "S")
                                .Replace("Ž", "Z")
                                .Replace("č", "c")
                                .Replace("ć", "c")
                                .Replace("đ", "d")
                                .Replace("š", "s")
                                .Replace("ž", "z")
                                .Replace("\\", "\\\\")
                                .Replace("(", "\\(")
                                .Replace(")", "\\)")
                                .Replace("[", "\\[")
                                .Replace("]", "\\]");
                            pdfSadrzaj += $"/F2 12 Tf ({cleanLine}) Tj 0 -15 Td\n";
                        }
                    }
                }
                        pdfSadrzaj += @"ET
                            endstream
                            endobj

                            xref
                            0 5
                            0000000000 65535 f 
                            0000000010 00000 n 
                            0000000053 00000 n 
                            0000000110 00000 n 
                            0000000175 00000 n 
                            trailer
                            <<
                            /Size 5
                            /Root 1 0 R
                            >>
                            startxref
                            500
                            %%EOF";
                
                return System.Text.Encoding.UTF8.GetBytes(pdfSadrzaj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }






    }
}
