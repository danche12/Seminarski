using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace KlijentskaAplikacija.Servisi.Mejl
{
    public class MejlPosiljalac
    {


        public bool PosaljiSaPdfPrilogom(string primalac, string naslov, string porukaHtml, string prilogIme, byte[] pdfBajtovi)
        {
            try
            {
                if (string.IsNullOrEmpty(SmtpPodesavanja.Host) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Korisnik) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Lozinka) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Posiljalac) ||
                    string.IsNullOrEmpty(primalac))
                {
                    return false;
                }

                var client = new SmtpClient(SmtpPodesavanja.Host, SmtpPodesavanja.Port);
                client.EnableSsl = SmtpPodesavanja.Ssl;
                client.Credentials = new NetworkCredential(SmtpPodesavanja.Korisnik, SmtpPodesavanja.Lozinka);

                var poruka = new MailMessage();
                poruka.From = new MailAddress(SmtpPodesavanja.Posiljalac);
                poruka.To.Add(new MailAddress(primalac));
                poruka.Subject = naslov;
                poruka.Body = porukaHtml;
                poruka.IsBodyHtml = true;

                // Dodaj PDF prilog
                var prilog = new Attachment(new MemoryStream(pdfBajtovi), prilogIme, "application/pdf");
                poruka.Attachments.Add(prilog);

                client.Send(poruka);
                return true;
            }
            catch (Exception ex)
            {
                // Log greške bez prikazivanja korisniku
                return false;
            }
        }

        public bool PosaljiTest(string primalac, string naslov, string porukaHtml)
        {
            try
            {
                if (string.IsNullOrEmpty(SmtpPodesavanja.Host) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Korisnik) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Lozinka) || 
                    string.IsNullOrEmpty(SmtpPodesavanja.Posiljalac) ||
                    string.IsNullOrEmpty(primalac))
                {
                    return false;
                }

                var client = new SmtpClient(SmtpPodesavanja.Host, SmtpPodesavanja.Port);
                client.EnableSsl = SmtpPodesavanja.Ssl;
                client.Credentials = new NetworkCredential(SmtpPodesavanja.Korisnik, SmtpPodesavanja.Lozinka);

                var poruka = new MailMessage();
                poruka.From = new MailAddress(SmtpPodesavanja.Posiljalac);
                poruka.To.Add(new MailAddress(primalac));
                poruka.Subject = naslov;
                poruka.Body = porukaHtml;
                poruka.IsBodyHtml = true;

                client.Send(poruka);
                return true;
            }
            catch (Exception ex)
            {
                // Log greške bez prikazivanja korisniku
                return false;
            }
        }
    }
}


