using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerFRMPretraziEvidencijuKursa
    {
      
            PretraziEvidencijuKursa pretraziEvidencijuKursa { get; set; }
            List<EvidencijaKursa> ucitaneEvidencijeKursa;
            KontrolerFRMKreirajEvidencijuKursa kontroler;
            public PretraziEvidencijuKursa Napravi()
            {
                pretraziEvidencijuKursa = new PretraziEvidencijuKursa();

                PopuniPodatke();

                pretraziEvidencijuKursa.BtnPretrazi.Click += BtnPretrazi_Click;
                pretraziEvidencijuKursa.BtnIzmeni.Click += BtnIzmeni_Click;
                kontroler = new KontrolerFRMKreirajEvidencijuKursa();
                return pretraziEvidencijuKursa;

            }

            private void BtnIzmeni_Click(object? sender, EventArgs e)
            {
                if (pretraziEvidencijuKursa.DgvEvidencije.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Niste selektovali evidenciju za izmenu");
                    return;
                }
                EvidencijaKursa evidencija = new EvidencijaKursa();
                evidencija = (EvidencijaKursa)pretraziEvidencijuKursa.DgvEvidencije.SelectedRows[0].DataBoundItem;
                KreirajEvidencijuKursa forma = kontroler.NapraviFormu(evidencija);
                forma.ShowDialog();
                PopuniPodatke();

            }

            private void BtnPretrazi_Click(object? sender, EventArgs e)
            {
                bool isValid = true;

                pretraziEvidencijuKursa.TxtIme.BackColor = Color.White;
                pretraziEvidencijuKursa.TxtPrezime.BackColor = Color.White;

                if (pretraziEvidencijuKursa.TxtIme.Text == "" && pretraziEvidencijuKursa.TxtPrezime.Text == "")
                {
                    pretraziEvidencijuKursa.DgvEvidencije.DataSource = new BindingList<EvidencijaKursa>(ucitaneEvidencijeKursa);
                    MessageBox.Show("Niste uneli kriterijume za pretragu");
                    return;
                }

                // Ime i Prezime – samo slova
                if (!pretraziEvidencijuKursa.TxtIme.Text.All(Char.IsLetter))
                {
                    isValid = false;
                    pretraziEvidencijuKursa.TxtIme.BackColor = Color.LightCoral;
                }
                if (!pretraziEvidencijuKursa.TxtPrezime.Text.All(Char.IsLetter))
                {
                    isValid = false;
                    pretraziEvidencijuKursa.TxtPrezime.BackColor = Color.LightCoral;
                }
                if (!isValid)
                {
                    MessageBox.Show("Uneti podaci nisu validni. Proverite označena polja.");
                    return;
                }

                Instruktor instruktor = new Instruktor();
                instruktor.Ime = pretraziEvidencijuKursa.TxtIme.Text;
                instruktor.Prezime = pretraziEvidencijuKursa.TxtPrezime.Text;



                // Pretraži po imenu i prezimenu instruktora direktno kroz JOIN alias 'i'
                string imeEsc = instruktor.Ime.Replace("'", "''");
                string prezimeEsc = instruktor.Prezime.Replace("'", "''");
                EvidencijaKursa evidencija = new EvidencijaKursa()
                {
                    Instruktor = instruktor,
                    Uslov = $"i.Ime = '{imeEsc}' AND i.Prezime = '{prezimeEsc}'"
                };

                Odgovor odgovor;

                try
                {
                    odgovor = Komunikacija.Instance.PretraziEvidencijeKursa(evidencija);




                    if (!odgovor.IsSuccessful)
                    {
                        MessageBox.Show($"Sistem ne moze da nadje evidenciju po zadatim kriterijumima\n");
                        pretraziEvidencijuKursa.DgvEvidencije.DataSource = new BindingList<EvidencijaKursa>();
                        return;
                    }

                    string jsonString = odgovor.Podatak.ToString();
                    List<EvidencijaKursa> evidencije = JsonSerializer.Deserialize<List<EvidencijaKursa>>(jsonString);
                    pretraziEvidencijuKursa.DgvEvidencije.DataSource = new BindingList<EvidencijaKursa>(evidencije);
                    pretraziEvidencijuKursa.DgvEvidencije.AllowUserToAddRows = false;
                    var dozvoljene = new[] { "DatumPocetka", "DatumZavrsetka", "Polaznik", "UkupnaCena" };
                    foreach (DataGridViewColumn c in pretraziEvidencijuKursa.DgvEvidencije.Columns)
                        c.Visible = dozvoljene.Contains(c.DataPropertyName) || dozvoljene.Contains(c.Name);


                    MessageBox.Show("Sistem je nasao evidenciju po zadatim kriterijumima");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska: " + ex.Message);
                    return;
                }
            }

            private void PopuniPodatke()
            {
                Odgovor odgovor;

                try
                {
                    odgovor = Komunikacija.Instance.VratiEvidencijeKursa();

                    if (!odgovor.IsSuccessful)
                    {
                        MessageBox.Show($"Sistem ne moze da ucita evidencije\n");
                        return;
                    }


                    string jsonString = odgovor.Podatak.ToString();
                    List<EvidencijaKursa> evidencije = JsonSerializer.Deserialize<List<EvidencijaKursa>>(jsonString);
                    BindingList<EvidencijaKursa> listaEvidencija = new BindingList<EvidencijaKursa>(evidencije);
                    pretraziEvidencijuKursa.DgvEvidencije.DataSource = listaEvidencija;
                    var g = pretraziEvidencijuKursa.DgvEvidencije;
                    g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    var dozvoljene = new[] { "DatumPocetka", "DatumZavrsetka", "Polaznik", "UkupnaCena" };
                    foreach (DataGridViewColumn c in pretraziEvidencijuKursa.DgvEvidencije.Columns)
                        c.Visible = dozvoljene.Contains(c.DataPropertyName) || dozvoljene.Contains(c.Name);
                    ucitaneEvidencijeKursa = evidencije;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska: " + ex.Message);
                    return;
                }


            }
        }
    }
