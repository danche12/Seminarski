using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domen;
using ServerskaAplikacija.Repozitorijum;
using System.Net.Mail;
using System.IO;

namespace ServerskaAplikacija.SistemskeOperacije
{
    public class PosaljiNedeljneMejloveSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi()
        {
            try
            {
                // Izračunaj početak sledeće nedelje (ponedeljak)
                DateTime danas = DateTime.Today;
                int danaDoPonedeljka = ((int)DayOfWeek.Monday - (int)danas.DayOfWeek + 7) % 7;
                DateTime pocetakSledeceNedelje = danas.AddDays(danaDoPonedeljka == 0 ? 7 : danaDoPonedeljka);
                DateTime krajSledeceNedelje = pocetakSledeceNedelje.AddDays(6);

                // Uzmi sve evidencije koje imaju časove u sledećoj nedelji
                List<EvidencijaKursa> evidencije = VratiEvidencijeZaNedelju(pocetakSledeceNedelje, krajSledeceNedelje);
                
                foreach (var evidencija in evidencije)
                {
                    if (evidencija.Polaznik != null && !string.IsNullOrEmpty(evidencija.Polaznik.Email))
                    {
                        // Generiši ICS kalendar za sledeću nedelju
                        string sadrzajIcs = GenerisiIcsZaNedelju(evidencija, pocetakSledeceNedelje);
                        
                        // Pošalji mejl sa ICS prilogom
                        PosaljiMejlSaIcs(evidencija.Polaznik, sadrzajIcs, pocetakSledeceNedelje, evidencija);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška pri slanju nedeljnih mejlova: {ex.Message}");
            }
        }

        private List<EvidencijaKursa> VratiEvidencijeZaNedelju(DateTime pocetakNedelje, DateTime krajNedelje)
        {
            List<EvidencijaKursa> evidencije = new List<EvidencijaKursa>();
            
            try
            {
                // Uzmi sve evidencije iz baze
                List<IEntitet> sveEvidencije = repozitorijum.VratiSve(new EvidencijaKursa());

                foreach (IEntitet entitet in sveEvidencije)
                {
                    EvidencijaKursa evidencija = (EvidencijaKursa)entitet;
                    
                    // Učitaj stavke za ovu evidenciju
                    evidencija.Stavke = repozitorijum.VratiPoUslovu(new StavkaEvidencijeKursa { Uslov = $"EvidencijaKursa = {evidencija.IdEvidencija}" }).Cast<StavkaEvidencijeKursa>().ToList();
                    
                    // Učitaj polaznika za ovu evidenciju
                    evidencija.Polaznik = (Polaznik)repozitorijum.VratiJednog(new Polaznik { Uslov = $"IdPolaznik = {evidencija.Polaznik.IdPolaznik}" });
                    
                    // Proveri da li evidencija ima stavke u sledećoj nedelji
                    if (evidencija.Stavke != null && evidencija.Stavke.Any(stavka => 
                        stavka.DatumOdrzavanja.Date >= pocetakNedelje && 
                        stavka.DatumOdrzavanja.Date <= krajNedelje))
                    {
                        evidencije.Add(evidencija);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška pri preuzimanju evidencija: {ex.Message}");
            }

            return evidencije;
        }

        private string GenerisiIcsZaNedelju(EvidencijaKursa evidencija, DateTime pocetakNedelje)
        {
            var stringBuilder = new StringBuilder();
            
            // ICS header
            stringBuilder.AppendLine("BEGIN:VCALENDAR");
            stringBuilder.AppendLine("VERSION:2.0");
            stringBuilder.AppendLine("PRODID:-//Kurs Digitalnih Tehnologija//Nedeljni Raspored//SR");
            stringBuilder.AppendLine("CALSCALE:GREGORIAN");
            stringBuilder.AppendLine("METHOD:PUBLISH");
            stringBuilder.AppendLine("X-WR-CALNAME:Raspored časova - Sledeća nedelja");

            // Filtrirane stavke za sledeću nedelju
            var stavkeZaNedelju = evidencija.Stavke?.Where(stavka => 
                stavka.DatumOdrzavanja.Date >= pocetakNedelje && 
                stavka.DatumOdrzavanja.Date <= pocetakNedelje.AddDays(6)) ?? new List<StavkaEvidencijeKursa>();

            foreach (var stavka in stavkeZaNedelju)
            {
                if (stavka.Cas != null)
                {
                    DateTime pocetakVreme = stavka.DatumOdrzavanja;
                    DateTime krajVreme = pocetakVreme.AddMinutes(stavka.Cas.TrajanjeCasa);

                    stringBuilder.AppendLine("BEGIN:VEVENT");
                    stringBuilder.AppendLine($"UID:{Guid.NewGuid()}@kurs-digitalnih-tehnologija.rs");
                    stringBuilder.AppendLine($"DTSTART:{pocetakVreme:yyyyMMddTHHmmss}");
                    stringBuilder.AppendLine($"DTEND:{krajVreme:yyyyMMddTHHmmss}");
                    stringBuilder.AppendLine($"SUMMARY:{stavka.Cas.TemaCasa}");
                    stringBuilder.AppendLine($"DESCRIPTION:Instruktor: {evidencija.Instruktor?.ImePrezime}\\nModul: {stavka.Cas.Modul}\\nCena: {stavka.Cena} RSD");
                    stringBuilder.AppendLine("LOCATION:Učionica 1");
                    stringBuilder.AppendLine("STATUS:CONFIRMED");
                    stringBuilder.AppendLine("TRANSP:OPAQUE");
                    stringBuilder.AppendLine("END:VEVENT");
                }
            }

            // ICS footer
            stringBuilder.AppendLine("END:VCALENDAR");

            return stringBuilder.ToString();
        }

        private void PosaljiMejlSaIcs(Polaznik polaznik, string sadrzajIcs, DateTime pocetakNedelje, EvidencijaKursa evidencija)
        {
            try
            {
                // SMTP konfiguracija (koristi iste podatke kao klijent)
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpKorisnik = "danicaadjurdjic@gmail.com";
                string smtpLozinka = "zexifizrilxxdbgs";
                string posiljalacEmail = "danicaadjurdjic@gmail.com";

                using (var klijent = new SmtpClient(smtpHost, smtpPort))
                {
                    klijent.EnableSsl = true;
                    klijent.Credentials = new System.Net.NetworkCredential(smtpKorisnik, smtpLozinka);

                    var poruka = new MailMessage();
                    poruka.From = new MailAddress(posiljalacEmail);
                    poruka.To.Add(new MailAddress(polaznik.Email));
                    poruka.Subject = $"Raspored časova - Nedelja {pocetakNedelje:dd.MM.yyyy}";

                    // Generiši tekstualni raspored za HTML poruku
                    string tekstualniRaspored = "";
                    if (evidencija.Stavke != null)
                    {
                        var stavkeZaNedelju = evidencija.Stavke.Where(stavka => 
                            stavka.DatumOdrzavanja.Date >= pocetakNedelje && 
                            stavka.DatumOdrzavanja.Date <= pocetakNedelje.AddDays(6));
                        
                        if (stavkeZaNedelju.Any())
                        {
                            tekstualniRaspored = "<h3>Raspored časova:</h3><ul>";
                            foreach (var stavka in stavkeZaNedelju.OrderBy(s => s.DatumOdrzavanja))
                            {
                                tekstualniRaspored += $"<li><strong>{stavka.DatumOdrzavanja:dd.MM.yyyy HH:mm}</strong> - {stavka.Cas?.TemaCasa} ({stavka.Cas?.Modul})</li>";
                            }
                            tekstualniRaspored += "</ul>";
                        }
                    }

                    string htmlPoruka = $@"
                        <h2>Raspored časova za sledeću nedelju</h2>
                        <p>Poštovani/a {polaznik.ImePrezime},</p>
                        <p>U prilogu se nalazi raspored časova za nedelju od <strong>{pocetakNedelje:dd.MM.yyyy}</strong>.</p>
                        {tekstualniRaspored}
                        <p>Ovaj raspored možete dodati u svoj kalendar klikom na prilog.</p>
                        <p>Srdačan pozdrav,<br/>Tim Kurs Digitalnih Tehnologija</p>
                    ";

                    poruka.Body = htmlPoruka;
                    poruka.IsBodyHtml = true;

                    // Dodaj ICS prilog
                    byte[] icsBajtovi = System.Text.Encoding.UTF8.GetBytes(sadrzajIcs);
                    var icsPrilog = new Attachment(new MemoryStream(icsBajtovi), "raspored_sledeca_nedelja.ics", "text/calendar");
                    poruka.Attachments.Add(icsPrilog);

                    klijent.Send(poruka);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška pri slanju mejla polazniku {polaznik.ImePrezime}: {ex.Message}");
            }
        }

    }
}
