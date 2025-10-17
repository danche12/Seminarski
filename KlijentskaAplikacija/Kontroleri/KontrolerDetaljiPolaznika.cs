using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerDetaljiPolaznika
    {
        public DetaljiPolaznika DetaljiPolaznika { get; set; }

        private Polaznik polaznik;

        public DetaljiPolaznika NapraviFormu(Polaznik polaznik)
        {

            this.polaznik = polaznik;
            DetaljiPolaznika = new DetaljiPolaznika();
            DetaljiPolaznika.FormBorderStyle = FormBorderStyle.Sizable;
            DetaljiPolaznika.StartPosition = FormStartPosition.CenterScreen;
            DetaljiPolaznika.BtnIzmeni.Click += BtnIzmeni_Click;

            PopuniPodatke();
            return DetaljiPolaznika;
        }

        private void BtnIzmeni_Click(object? sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(DetaljiPolaznika.TxtIme.Text) ||
                string.IsNullOrEmpty(DetaljiPolaznika.TxtPrezime.Text) ||
                string.IsNullOrEmpty(DetaljiPolaznika.TxtBrojTelefona.Text))
            {
                MessageBox.Show("Sistem ne moze da zapamti polaznika");
                return;
            }
            // Validacija datuma - ne sme biti u budućnosti
            if (DetaljiPolaznika.DtDatumRodjenja.Value > DateTime.Now)
            {
                DetaljiPolaznika.DtDatumRodjenja.BackColor = Color.LightCoral;
                MessageBox.Show("Datum ne moze biti u buducnosti");
                return;
            }
            Polaznik novi = new Polaznik()
            {
                Ime = DetaljiPolaznika.TxtIme.Text,
                Prezime = DetaljiPolaznika.TxtPrezime.Text,
                BrojTelefona = DetaljiPolaznika.TxtBrojTelefona.Text,
                DatumRodjenja = DetaljiPolaznika.DtDatumRodjenja.Value,  
                Prebivaliste = (Prebivaliste)DetaljiPolaznika.CmbPrebivalista.SelectedItem,  
                IdPolaznik = polaznik.IdPolaznik
            };
            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.AzurirajPolaznika(novi);
                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti polaznika\n");
                    return;
                }

                MessageBox.Show($"Sistem je zapamtio polaznika");
                DetaljiPolaznika.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }

        private void PopuniPodatke()
        {
            Odgovor odg = Komunikacija.Instance.VratiPrebivalista();
            List<Prebivaliste> rezultat = Komunikacija.Instance.jns.ReadType<List<Prebivaliste>>(odg.Podatak);


            DetaljiPolaznika.TxtIme.Text = polaznik.Ime;
            DetaljiPolaznika.TxtPrezime.Text = polaznik.Prezime;
            DetaljiPolaznika.TxtBrojTelefona.Text = polaznik.BrojTelefona;
            DetaljiPolaznika.DtDatumRodjenja.Value = polaznik.DatumRodjenja;
            DetaljiPolaznika.CmbPrebivalista.DataSource = rezultat;
            DetaljiPolaznika.CmbPrebivalista.DisplayMember = "NazivMesta";      // property koji prikazuje korisniku
            DetaljiPolaznika.CmbPrebivalista.ValueMember = "IdPrebivaliste";  // property koji služi kao ključ

            // sada postavi default vrednost na onu iz polaznika
            DetaljiPolaznika.CmbPrebivalista.SelectedValue = polaznik.Prebivaliste.IdPrebivaliste;
        }
    }
}

