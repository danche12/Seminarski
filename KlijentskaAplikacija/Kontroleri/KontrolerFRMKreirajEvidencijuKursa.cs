using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms; 
using System.Drawing;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerFRMKreirajEvidencijuKursa
    {
        KreirajEvidencijuKursa kreirajEvidencijuKursa { get; set; }

        public List<StavkaEvidencijeKursa> stavke;
        public List<StavkaEvidencijeKursa> stavkeZaBrisanje;
        EvidencijaKursa evidencija;
        EvidencijaKursa evidencijaZaIzmenu;
        double ukupanIznos;
        private bool datumiZakljucani = false;
        public KreirajEvidencijuKursa NapraviUC()
        {
            kreirajEvidencijuKursa = new KreirajEvidencijuKursa();
            kreirajEvidencijuKursa.Label8.Text = "KREIRANJE EVIDENCIJE KURSA";
            kreirajEvidencijuKursa.BtnPotvrdaIzmene.Visible = false;
            kreirajEvidencijuKursa.BtnSacuvaj.Visible = true;
            kreirajEvidencijuKursa.DatumPocetka.MinDate = DateTime.Today;
            kreirajEvidencijuKursa.DatumZavrsetka.MinDate = DateTime.Today;

            kreirajEvidencijuKursa.DatumPocetka.ValueChanged += DatumPocetka_ValueChanged;
            kreirajEvidencijuKursa.DatumZavrsetka.ValueChanged += DatumZavrsetka_ValueChanged;
            kreirajEvidencijuKursa.CmbModul.SelectedIndexChanged += CmbModul_SelectedIndexChanged;
            kreirajEvidencijuKursa.BtnDodajStavku.Click += BtnDodajStavku_Click;
            kreirajEvidencijuKursa.BtnSacuvaj.Click += BtnSacuvaj_Click;
            kreirajEvidencijuKursa.BtnObrisi.Click += BtnObrisi_Click;
            kreirajEvidencijuKursa.BtnExportPdf.Click += BtnExportPdf_Click;
            PopuniPodatke();

            stavke = new List<StavkaEvidencijeKursa>();

            return kreirajEvidencijuKursa;
        }

        private void DatumPocetka_ValueChanged(object? sender, EventArgs e)
        {
            kreirajEvidencijuKursa.DatumZavrsetka.MinDate = kreirajEvidencijuKursa.DatumPocetka.Value;
        }

        private void DatumZavrsetka_ValueChanged(object? sender, EventArgs e)
        {
            kreirajEvidencijuKursa.DatumOdrzavanja.MinDate = kreirajEvidencijuKursa.DatumPocetka.Value;
            kreirajEvidencijuKursa.DatumOdrzavanja.MaxDate = kreirajEvidencijuKursa.DatumZavrsetka.Value;
        }


        private void BtnObrisi_Click(object? sender, EventArgs e)
        {
            if (kreirajEvidencijuKursa.DgvStavke.SelectedRows.Count > 0)
            {

                StavkaEvidencijeKursa s = (StavkaEvidencijeKursa)kreirajEvidencijuKursa.DgvStavke.SelectedRows[0].DataBoundItem;
                stavke.Remove(s);
                if (s.EvidencijaKursa != null)
                    stavkeZaBrisanje.Add(s);

                osveziRacun();
            }
            else
            {
                MessageBox.Show("Molim vas odaberite stavku za brisanje!");
                return;
            }
        }

        private void BtnSacuvaj_Click(object? sender, EventArgs e)
        {
            if (stavke.Count() == 0)
            {
                MessageBox.Show("Molim vas da dodate stavke!");
                return;
            }
            if (kreirajEvidencijuKursa.CmbPolaznik.SelectedIndex < 0)
            {
                MessageBox.Show("Molim vas odaberite polaznika");
                kreirajEvidencijuKursa.CmbPolaznik.BackColor = Color.Salmon;
                return;
            }


            EvidencijaKursa evidencijaKursa = new EvidencijaKursa()
            {
                DatumPocetka = kreirajEvidencijuKursa.DatumPocetka.Value,
                DatumZavrsetka = kreirajEvidencijuKursa.DatumZavrsetka.Value,
                Instruktor = (Instruktor)kreirajEvidencijuKursa.CmbInstruktor.SelectedItem,
                Polaznik = (Polaznik)kreirajEvidencijuKursa.CmbPolaznik.SelectedItem,
                UkupnaCena = Double.Parse(kreirajEvidencijuKursa.TxtUkupanIznos.Text),
                Stavke = stavke
            };

            Odgovor o = new Odgovor();

            try
            {
                o = Komunikacija.Instance.ZapamtiEvidencijuKursa(evidencijaKursa);
                if (o.IsSuccessful)
                {
                    MessageBox.Show("Sistem je zapamtio evidenciju");
                    
                    var polaznik = (Polaznik)kreirajEvidencijuKursa.CmbPolaznik.SelectedItem;
                    var instruktor = (Instruktor)kreirajEvidencijuKursa.CmbInstruktor.SelectedItem;
                    
                    if (polaznik != null && !string.IsNullOrEmpty(polaznik.Email))
                    {
                        try
                        {
                            string odabraniModul = kreirajEvidencijuKursa.CmbModul.SelectedItem?.ToString() ?? "Nije odabran";
                            
                            var mejlPosiljalac = new KlijentskaAplikacija.Servisi.Mejl.MejlPosiljalac();
                            var pdfGenerator = new KlijentskaAplikacija.Servisi.Pdf.PdfGenerator();
                            
                            string naslov = "RASPORED ČASOVA";
                            string pdfSadrzaj = $"**MODUL:** {odabraniModul}\n";
                            pdfSadrzaj += $"**INSTRUKTOR:** {instruktor?.ImePrezime ?? "Nije odabran"}\n";
                            pdfSadrzaj += $"**POLAZNIK:** {polaznik?.ImePrezime ?? "Nije odabran"}\n";
                            pdfSadrzaj += $"**PERIOD:** {kreirajEvidencijuKursa.DatumPocetka.Value:dd.MM.yyyy} - {kreirajEvidencijuKursa.DatumZavrsetka.Value:dd.MM.yyyy}\n\n";
                            pdfSadrzaj += "**RASPORED ČASOVA:**\n\n";

                            int redniBroj = 1;
                            foreach (var stavka in stavke)
                            { 
                                pdfSadrzaj += $"{redniBroj}. čas - {stavka.Cas?.TemaCasa} ({stavka.Cas?.Modul})\n";
                                pdfSadrzaj += $"  {stavka.DatumOdrzavanja:dd.MM.yyyy HH:mm}\n";
                                pdfSadrzaj += $"  Cena: {stavka.Cena} RSD\n\n";
                                redniBroj++;
                            }

                            pdfSadrzaj += $"UKUPNA CENA: {kreirajEvidencijuKursa.TxtUkupanIznos.Text} RSD\n";
                            pdfSadrzaj += $"Generisano: {DateTime.Now:dd.MM.yyyy HH:mm}";

                            byte[] pdfBajtovi = pdfGenerator.GenerisiRasporedCasovaUBajtovima(naslov, pdfSadrzaj);
                            
                            string htmlPoruka = $@"
                                <h2>Potvrda prijave na modul</h2>
                                <p>Poštovani/a {polaznik.ImePrezime},</p>
                                <p>Uspešno ste prijavljeni na modul <strong>""{odabraniModul}""</strong> u okviru Kursa Digitalnih Tehnologija.</p>
                                <p><strong>Instruktor:</strong> {instruktor?.ImePrezime ?? "Nije odabran"}</p>
                                <p><strong>Period:</strong> {kreirajEvidencijuKursa.DatumPocetka.Value:dd.MM.yyyy} - {kreirajEvidencijuKursa.DatumZavrsetka.Value:dd.MM.yyyy}</p>
                                <p><strong>Ukupna cena:</strong> {kreirajEvidencijuKursa.TxtUkupanIznos.Text} RSD</p>
                                <p>U prilogu se nalazi detaljan raspored časova u PDF formatu.</p>
                                <p>Srdačan pozdrav,<br/>Tim Kurs Digitalnih Tehnologija</p>
                            ";
                            
                            bool uspesno = false;
                            if (pdfBajtovi != null)
                            {
                                uspesno = mejlPosiljalac.PosaljiSaPdfPrilogom(polaznik.Email, $"Potvrda prijave - Modul {odabraniModul}", htmlPoruka, "Raspored_casova.pdf", pdfBajtovi);
                            }
                            else
                            {
                                uspesno = mejlPosiljalac.PosaljiTest(polaznik.Email, $"Potvrda prijave - Modul {odabraniModul}", htmlPoruka);
                            }
                            
                            if (uspesno)
                            {
                                MessageBox.Show($"Raspored je uspešno poslat na email: {polaznik.Email}");
                            }
                            else
                            {
                                MessageBox.Show($"Greška pri slanju mejla na adresu: {polaznik.Email}\nProverite SMTP podešavanja.\n\nTrenutne SMTP podešavanja:\nHost: {KlijentskaAplikacija.Servisi.Mejl.SmtpPodesavanja.Host}\nPort: {KlijentskaAplikacija.Servisi.Mejl.SmtpPodesavanja.Port}\nKorisnik: {KlijentskaAplikacija.Servisi.Mejl.SmtpPodesavanja.Korisnik}");
                            }
                        }
                        catch (Exception emailEx)
                        {
                            MessageBox.Show($"Greška pri slanju mejla: {emailEx.Message}\n\nDetalji:\n{emailEx}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Polaznik {polaznik?.ImePrezime} nema email adresu, mejl nije poslat.");
                    }
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da zapamti evidenciju");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
            Resetovanje();

        }

        private void Resetovanje()
        {
            kreirajEvidencijuKursa.CmbPolaznik.Enabled = true;
            kreirajEvidencijuKursa.CmbPolaznik.SelectedIndex = -1;

            kreirajEvidencijuKursa.CmbInstruktor.Enabled = true;
            kreirajEvidencijuKursa.CmbInstruktor.SelectedIndex = -1;

            // Očisti ComboBox za module
            kreirajEvidencijuKursa.CmbModul.SelectedIndex = -1;
            
            // Očisti ComboBox za časove
            kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;

            kreirajEvidencijuKursa.DgvStavke.DataSource = null;
            kreirajEvidencijuKursa.TxtCena.Text = null;
            kreirajEvidencijuKursa.TxtUkupanIznos.Text = null;
            stavke = new List<StavkaEvidencijeKursa>();

            datumiZakljucani = false;
            kreirajEvidencijuKursa.DatumPocetka.Enabled = true;
            kreirajEvidencijuKursa.DatumZavrsetka.Enabled = true;
        }

        private void BtnDodajStavku_Click(object? sender, EventArgs e)
        {
            if (kreirajEvidencijuKursa.CmbPolaznik.SelectedIndex < 0)
            {
                MessageBox.Show("Molim vas da odaberete polaznika");
                return;
            }
            // Proveri modul samo ako nije u edit modu (ComboBox je vidljiv)
            if (kreirajEvidencijuKursa.CmbModul.Visible && kreirajEvidencijuKursa.CmbModul.SelectedIndex < 0)
            {
                MessageBox.Show("Molim vas odaberite modul");
                kreirajEvidencijuKursa.CmbModul.BackColor = Color.Salmon;
                return;
            }
            if (kreirajEvidencijuKursa.CmbInstruktor.SelectedIndex < 0)
            {
                MessageBox.Show("Molim vas da odaberete nastavnika");
                return;
            }
            // Omogućava menjanje podataka sve dok se ne klikne Sačuvaj
            // kreirajEvidencijuKursa.CmbInstruktor.Enabled = false;
            // kreirajEvidencijuKursa.CmbPolaznik.Enabled = false;


            if (kreirajEvidencijuKursa.CmbCas.SelectedIndex < 0)
            {
                MessageBox.Show("Molim vas da odaberete cas");
                return;
            }

            // Proveri da li se čas pripada odabranom modulu
            string izabraniModul;
            if (kreirajEvidencijuKursa.CmbModul.Visible)
            {
                // Kreiranje novog - uzmi iz ComboBox-a
                izabraniModul = kreirajEvidencijuKursa.CmbModul.SelectedItem.ToString();
            }
            else
            {
                // Edit mod - uzmi iz postojećih stavki
                izabraniModul = stavke?.FirstOrDefault()?.Cas?.Modul ?? "";
            }
            
            Cas izabraniCas = (Cas)kreirajEvidencijuKursa.CmbCas.SelectedItem;
            if (izabraniCas.Modul != izabraniModul)
            {
                MessageBox.Show($"Čas '{izabraniCas.TemaCasa}' ne pripada modulu '{izabraniModul}'. Molim vas odaberite čas koji pripada odabranom modulu.");
                return;
            }

            if (kreirajEvidencijuKursa.DatumOdrzavanja.Value < kreirajEvidencijuKursa.DatumPocetka.Value ||
                kreirajEvidencijuKursa.DatumOdrzavanja.Value > kreirajEvidencijuKursa.DatumZavrsetka.Value)
            { 
                MessageBox.Show($"Datum održavanja časa mora biti između {kreirajEvidencijuKursa.DatumPocetka.Value:dd.MM.yyyy} i {kreirajEvidencijuKursa.DatumZavrsetka.Value:dd.MM.yyyy}");
                return;
            }

            // Omogućava menjanje datuma sve dok se ne klikne Sačuvaj
            // kreirajEvidencijuKursa.CmbPolaznik.Enabled = false;
            // kreirajEvidencijuKursa.CmbInstruktor.Enabled = false;
            // kreirajEvidencijuKursa.DatumPocetka.Enabled = false;
            // kreirajEvidencijuKursa.DatumZavrsetka.Enabled = false;

            Cas cas = (Cas)kreirajEvidencijuKursa.CmbCas.SelectedItem;
            StavkaEvidencijeKursa stavka = new StavkaEvidencijeKursa()
            {
                Cas = cas,
                Cena = (double)cas.CenaCasa,
                DatumOdrzavanja = kreirajEvidencijuKursa.DatumOdrzavanja.Value
            };
            if (stavke == null || stavke.Count == 0)
                stavka.Rb = 1;
            else
                stavka.Rb = stavke.Max(s => s.Rb) + 1;


            foreach (StavkaEvidencijeKursa s in stavke)
            {
                if (s.Cas?.IdCas == cas?.IdCas)
                {
                    MessageBox.Show($"Vec ste dodali cas {cas.TemaCasa}");
                    return;
                }
            }
            stavke.Add(stavka);
            osveziRacun();
        }

        private void osveziRacun()
        {
            double ukupanIznos = 0;
            double cena = 0;
            for (int i = 0; i < stavke.Count(); i++)
            {
                cena = stavke[i].Cena;
                ukupanIznos += stavke[i].Cena;

            }
            kreirajEvidencijuKursa.TxtUkupanIznos.Text = ukupanIznos.ToString();
            kreirajEvidencijuKursa.TxtCena.Text = cena.ToString();

            BindingList<StavkaEvidencijeKursa> novalista = new BindingList<StavkaEvidencijeKursa>(stavke);
            kreirajEvidencijuKursa.DgvStavke.DataSource = null;
            kreirajEvidencijuKursa.DgvStavke.DataSource = stavke;
            kreirajEvidencijuKursa.DgvStavke.Columns[0].Visible = false;
            kreirajEvidencijuKursa.DgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var dozvoljene = new[] { "Rb", "Cena", "TemaCasa", "Modul", "DatumOdrzavanja" };
            foreach (DataGridViewColumn c in kreirajEvidencijuKursa.DgvStavke.Columns)
            {
                c.Visible = dozvoljene.Contains(c.DataPropertyName) || dozvoljene.Contains(c.Name);
                
                // Formatiraj kolonu za datum i vreme
                if (c.DataPropertyName == "DatumOdrzavanja")
                {
                    c.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    c.HeaderText = "Datum i vreme";
                }
            }
        }

        private void PopuniPodatke()
        {
            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.VratiInstruktore();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita nastavnike\n");
                    return;
                }


                string jsonString = odgovor.Podatak.ToString();
                List<Instruktor> nastavnici = JsonSerializer.Deserialize<List<Instruktor>>(jsonString);
                kreirajEvidencijuKursa.CmbInstruktor.DataSource = nastavnici;

                kreirajEvidencijuKursa.CmbInstruktor.SelectedIndex = -1;

                odgovor = Komunikacija.Instance.VratiPolaznike();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita polaznike\n");
                    return;
                }

                string jsonString2 = odgovor.Podatak.ToString();
                List<Polaznik> polaznici = JsonSerializer.Deserialize<List<Polaznik>>(jsonString2);
                kreirajEvidencijuKursa.CmbPolaznik.DataSource = polaznici;
                kreirajEvidencijuKursa.CmbPolaznik.SelectedIndex = -1;

                odgovor = Komunikacija.Instance.VratiCasove();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita casove\n");
                    return;
                }

                string jsonString3 = odgovor.Podatak.ToString();
                List<Cas> casovi = JsonSerializer.Deserialize<List<Cas>>(jsonString3);
                kreirajEvidencijuKursa.CmbCas.DataSource = casovi;
                kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;

                // Popuni module
                List<string> moduli = new List<string>
                {
                    "Web dizajn",
                    "Graficki dizajn", 
                    "Digitalni marketing",
                    "Fotografija",
                    "Video produkcija",
                    "Mobile app razvoj"
                };
                kreirajEvidencijuKursa.CmbModul.DataSource = moduli;
                kreirajEvidencijuKursa.CmbModul.SelectedIndex = -1;

                kreirajEvidencijuKursa.TxtCena.ReadOnly = true;
                kreirajEvidencijuKursa.TxtUkupanIznos.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }

        public KreirajEvidencijuKursa NapraviFormu(EvidencijaKursa evidencija)
        {
            evidencijaZaIzmenu = new EvidencijaKursa();
            evidencijaZaIzmenu.IdEvidencija = evidencija.IdEvidencija;
            evidencijaZaIzmenu.Polaznik = evidencija.Polaznik;
            evidencijaZaIzmenu.Instruktor = evidencija.Instruktor;
            kreirajEvidencijuKursa = new KreirajEvidencijuKursa();
            kreirajEvidencijuKursa.Label8.Text = "IZMENA EVIDENCIJE KURSA";
            kreirajEvidencijuKursa.BtnSacuvaj.Visible = false;
            kreirajEvidencijuKursa.BtnPotvrdaIzmene.Visible = true;
            kreirajEvidencijuKursa.BtnDodajStavku.Click += BtnDodajStavku_Click;
            kreirajEvidencijuKursa.BtnSacuvaj.Click += BtnSacuvaj_Click;
            kreirajEvidencijuKursa.BtnObrisi.Click += BtnObrisi_Click;
            kreirajEvidencijuKursa.BtnExportPdf.Click += BtnExportPdf_Click;
            stavkeZaBrisanje = new List<StavkaEvidencijeKursa>();
            kreirajEvidencijuKursa.BtnPotvrdaIzmene.Click += BtnPotvrdaIzmene_Click;

            evidencijaZaIzmenu.IdEvidencija = evidencija.IdEvidencija;
            evidencijaZaIzmenu.Polaznik = evidencija.Polaznik;
            evidencijaZaIzmenu.Instruktor = evidencija.Instruktor;
            kreirajEvidencijuKursa.DatumPocetka.MinDate = DateTime.Today;
            kreirajEvidencijuKursa.DatumZavrsetka.MinDate = DateTime.Today;

            stavkeZaBrisanje = new List<StavkaEvidencijeKursa>();


            Odgovor odgovor = Komunikacija.Instance.UcitajUgovor(evidencija);
            string jsonString4 = odgovor.Podatak.ToString();
            EvidencijaKursa novaEvidencija = JsonSerializer.Deserialize<EvidencijaKursa>(jsonString4);
            if (novaEvidencija == null)
            {
                novaEvidencija = new EvidencijaKursa();
                novaEvidencija.Instruktor = evidencija.Instruktor;
                novaEvidencija.Polaznik = evidencija.Polaznik;
                novaEvidencija.Stavke = new List<StavkaEvidencijeKursa>();
            }

            try
            {
                odgovor = Komunikacija.Instance.VratiInstruktore();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita instruktore\n");
                    return null;
                }


                string jsonString = odgovor.Podatak.ToString();
                List<Instruktor> instruktori = JsonSerializer.Deserialize<List<Instruktor>>(jsonString);
                // Prikaz koristi ToString() (Ime Prezime); vrednost je IdInstruktor
                kreirajEvidencijuKursa.CmbInstruktor.DisplayMember = "ImePrezime";
                kreirajEvidencijuKursa.CmbInstruktor.ValueMember = "IdInstruktor";
                kreirajEvidencijuKursa.CmbInstruktor.DataSource = instruktori;
                kreirajEvidencijuKursa.CmbInstruktor.SelectedValue = evidencija.Instruktor.IdInstruktor;
                // Onemogući menjanje instruktora u edit modu
                kreirajEvidencijuKursa.CmbInstruktor.Enabled = false;

                odgovor = Komunikacija.Instance.VratiPolaznike();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita polaznike\n");
                    return null;
                }

                string jsonString2 = odgovor.Podatak.ToString();
                List<Polaznik> polaznici = JsonSerializer.Deserialize<List<Polaznik>>(jsonString2);

                kreirajEvidencijuKursa.CmbPolaznik.DisplayMember = "ImePrezime";
                kreirajEvidencijuKursa.CmbPolaznik.ValueMember = "IdPolaznik";
                kreirajEvidencijuKursa.CmbPolaznik.DataSource = polaznici;
                kreirajEvidencijuKursa.CmbPolaznik.SelectedValue = evidencija.Polaznik.IdPolaznik;
                // Onemogući menjanje polaznika u edit modu
                kreirajEvidencijuKursa.CmbPolaznik.Enabled = false;
                odgovor = Komunikacija.Instance.VratiCasove();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da ucita casove\n");
                    return null;
                }

                string jsonString3 = odgovor.Podatak.ToString();
                List<Cas> casovi = JsonSerializer.Deserialize<List<Cas>>(jsonString3);
                // U combo uvek prikaži SVE časove iz baze
                kreirajEvidencijuKursa.CmbCas.DataSource = casovi;
                kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;

                kreirajEvidencijuKursa.TxtCena.ReadOnly = true;
                kreirajEvidencijuKursa.TxtUkupanIznos.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return null;
            }

            // Omogućava menjanje podataka sve dok se ne klikne Sačuvaj
            // kreirajEvidencijuKursa.CmbInstruktor.Enabled = false;
            // kreirajEvidencijuKursa.CmbPolaznik.Enabled = false;
            kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;

            kreirajEvidencijuKursa.TxtCena.ReadOnly = true;
            kreirajEvidencijuKursa.TxtUkupanIznos.ReadOnly = true;


            // Postavi datume i ukupnu cenu iz postojeće evidencije (oslobodi MinDate/MaxDate da ne baci izuzetak)
            if (novaEvidencija != null)
            {
                kreirajEvidencijuKursa.DatumPocetka.MinDate = DateTimePicker.MinimumDateTime;
                kreirajEvidencijuKursa.DatumZavrsetka.MinDate = DateTimePicker.MinimumDateTime;
                kreirajEvidencijuKursa.DatumPocetka.Value = novaEvidencija.DatumPocetka;
                kreirajEvidencijuKursa.DatumZavrsetka.Value = novaEvidencija.DatumZavrsetka;
                kreirajEvidencijuKursa.DatumOdrzavanja.MinDate = kreirajEvidencijuKursa.DatumPocetka.Value;
                kreirajEvidencijuKursa.DatumOdrzavanja.MaxDate = kreirajEvidencijuKursa.DatumZavrsetka.Value;
                kreirajEvidencijuKursa.TxtUkupanIznos.Text = novaEvidencija.UkupnaCena.ToString();
                
                // Onemogući menjanje datum početka u edit modu
                kreirajEvidencijuKursa.DatumPocetka.Enabled = false;
            }

            BindingList<StavkaEvidencijeKursa> noveStavke = new BindingList<StavkaEvidencijeKursa>(novaEvidencija.Stavke ?? new List<StavkaEvidencijeKursa>());
            if (novaEvidencija.Stavke == null)
            {
                stavke = new List<StavkaEvidencijeKursa>();
            }
            else
            {
                stavke = novaEvidencija.Stavke;
            }
            
            // Odredi modul iz postojećih stavki i sakrij ComboBox za modul u edit modu
            if (stavke != null && stavke.Count > 0)
            {
                // Uzmi modul iz prve stavke (sve stavke treba da budu istog modula)
                string modulIzStavki = stavke.FirstOrDefault()?.Cas?.Modul ?? "Nije određen";
                
                // Sakrij ComboBox za modul i prikaži naziv modula u Labeli
                kreirajEvidencijuKursa.CmbModul.Visible = false;
                kreirajEvidencijuKursa.LabelModul.Text = $"Modul: {modulIzStavki}";
                kreirajEvidencijuKursa.LabelModul.Visible = true;
            }
            else
            {
                // Ako nema stavki, sakrij oba
                kreirajEvidencijuKursa.CmbModul.Visible = false;
                kreirajEvidencijuKursa.LabelModul.Visible = false;
            }
            
            kreirajEvidencijuKursa.DgvStavke.DataSource = noveStavke;
            kreirajEvidencijuKursa.DgvStavke.Columns[0].Visible = false;
            kreirajEvidencijuKursa.DgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var dozvoljene = new[] { "Rb", "Cena", "TemaCasa", "Modul", "DatumOdrzavanja" };
            foreach (DataGridViewColumn c in kreirajEvidencijuKursa.DgvStavke.Columns)
            {
                c.Visible = dozvoljene.Contains(c.DataPropertyName) || dozvoljene.Contains(c.Name);
                
                // Formatiraj kolonu za datum i vreme
                if (c.DataPropertyName == "DatumOdrzavanja")
                {
                    c.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    c.HeaderText = "Datum i vreme";
                }
            }

            return kreirajEvidencijuKursa;
        }

        private void BtnPotvrdaIzmene_Click(object? sender, EventArgs e)
        {
            if (stavke == null || stavke.Count == 0)
            {
                MessageBox.Show("Evidencija ne može biti sačuvana bez stavki.");
                return;
            }
            evidencijaZaIzmenu.Stavke = stavke;
            evidencijaZaIzmenu.StavkeZaBrisanje = stavkeZaBrisanje;

            Odgovor odgovor = Komunikacija.Instance.AzurirajEvidenciju(evidencijaZaIzmenu);

            if (odgovor.IsSuccessful)
            {
                MessageBox.Show("Sistem je zapamtio evidenciju kursa");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti evidenciju kursa");
            }

            kreirajEvidencijuKursa.Dispose();
         }


         private void BtnExportPdf_Click(object? sender, EventArgs e)
         {
             if (stavke == null || stavke.Count == 0)
             {
                 MessageBox.Show("Nema stavki za export u PDF.");
                 return;
             }

             var pdfGenerator = new KlijentskaAplikacija.Servisi.Pdf.PdfGenerator();
             
             // Generiši sadržaj na osnovu stvarnih podataka
             var instruktor = kreirajEvidencijuKursa.CmbInstruktor.SelectedItem as Instruktor;
             var polaznik = kreirajEvidencijuKursa.CmbPolaznik.SelectedItem as Polaznik;
             
             string naslov = "RASPORED ČASOVA";
             string sadrzaj = $"**KURS:** Kurs Digitalnih Tehnologija\n";
             sadrzaj += $"**INSTRUKTOR:** {instruktor?.ImePrezime ?? "Nije odabran"}\n";
             sadrzaj += $"**POLAZNIK:** {polaznik?.ImePrezime ?? "Nije odabran"}\n";
             sadrzaj += $"**PERIOD:** {kreirajEvidencijuKursa.DatumPocetka.Value:dd.MM.yyyy} - {kreirajEvidencijuKursa.DatumZavrsetka.Value:dd.MM.yyyy}\n\n";
             sadrzaj += "**RASPORED ČASOVA:**\n\n";

            int redniBroj = 1;
            foreach (var stavka in stavke)
            {
                 sadrzaj += $"{redniBroj}. čas - {stavka.DatumOdrzavanja:dd.MM.yyyy HH:mm}\n";
                 sadrzaj += $"  {stavka.Cas?.TemaCasa}\n";
                 sadrzaj += $"  Cena: {stavka.Cena} RSD\n";
                 redniBroj++;
             }

             sadrzaj += $"UKUPNA CENA: {kreirajEvidencijuKursa.TxtUkupanIznos.Text} RSD\n";
             sadrzaj += $"Generisano: {DateTime.Now:dd.MM.yyyy HH:mm}";

             // Koristi metodu za generisanje PDF-a u bajtovima za email priloge
             byte[] pdfBajtovi = pdfGenerator.GenerisiRasporedCasovaUBajtovima(naslov, sadrzaj);
             
             if (pdfBajtovi != null)
             {
                 try
                 {
                     // Sačuvaj PDF na desktop
                     string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                     string fileName = $"Raspored_casova_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                     string filePath = Path.Combine(desktopPath, fileName);
                     
                     File.WriteAllBytes(filePath, pdfBajtovi);
                     MessageBox.Show($"PDF raspored je sačuvan na Desktop-u: {fileName}");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show($"Greška pri čuvanju PDF-a: {ex.Message}");
                 }
             }
             else
             {
                 MessageBox.Show("Sistem ne može da generiše PDF raspored.");
             }
         }

         private void CmbModul_SelectedIndexChanged(object? sender, EventArgs e)
         {
             if (kreirajEvidencijuKursa.CmbModul.SelectedItem == null)
             {
                 // Ako nije odabran modul, prikaži sve časove
                 Odgovor odgovor = Komunikacija.Instance.VratiCasove();
                 if (odgovor.IsSuccessful)
                 {
                     string jsonString = odgovor.Podatak.ToString();
                     List<Cas> sviCasovi = JsonSerializer.Deserialize<List<Cas>>(jsonString);
                     kreirajEvidencijuKursa.CmbCas.DataSource = sviCasovi;
                     kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;
                 }
                 return;
             }

             string izabraniModul = kreirajEvidencijuKursa.CmbModul.SelectedItem.ToString();
             
             // Uzmi sve časove i filtriraj po modulu
             Odgovor odgovor2 = Komunikacija.Instance.VratiCasove();
             if (odgovor2.IsSuccessful)
             {
                 string jsonString2 = odgovor2.Podatak.ToString();
                 List<Cas> sviCasovi = JsonSerializer.Deserialize<List<Cas>>(jsonString2);
                 
                 // Filtriraj časove po modulu
                 List<Cas> filtriraniCasovi = sviCasovi.Where(c => c.Modul == izabraniModul).ToList();
                 
                 kreirajEvidencijuKursa.CmbCas.DataSource = filtriraniCasovi;
                 kreirajEvidencijuKursa.CmbCas.SelectedIndex = -1;
             }
        }
    }
}
