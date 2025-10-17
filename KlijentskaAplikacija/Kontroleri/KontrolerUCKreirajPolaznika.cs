using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerUCKreirajPolaznika
    {
        public UCKreiranjePolaznika UCKreiranjePolaznika { get; set; }

        private List<Prebivaliste> prebivalista = new List<Prebivaliste>();
        public UCKreiranjePolaznika NapraviUC()
        {
            UCKreiranjePolaznika = new UCKreiranjePolaznika();
            PopuniPodatke();
            UCKreiranjePolaznika.CmbPrebivalista.DataSource = prebivalista;
            UCKreiranjePolaznika.CmbPrebivalista.SelectedIndex = -1;

            UCKreiranjePolaznika.BtnZapamti.Click += BtnZapamti_Click;
            return UCKreiranjePolaznika;
        }

        private void PopuniPodatke()
        {

            Odgovor odg = Komunikacija.Instance.VratiPrebivalista();
            List<Prebivaliste> rezultat = Komunikacija.Instance.jns.ReadType<List<Prebivaliste>>(odg.Podatak);
            prebivalista = rezultat;
        }

        private void BtnZapamti_Click(object? sender, EventArgs e)
        {
            bool isValid = true;


            // Ime i Prezime – samo slova
            if (!UCKreiranjePolaznika.TxtIme.Text.All(Char.IsLetter))
            {
                isValid = false;
                UCKreiranjePolaznika.TxtIme.BackColor = Color.LightCoral;
            }
            if (!UCKreiranjePolaznika.TxtPrezime.Text.All(Char.IsLetter))
            {
                isValid = false;
                UCKreiranjePolaznika.TxtPrezime.BackColor = Color.LightCoral;
            }
            // Broj telefona – validacija za string format
            if (!IsValidPhoneNumber(UCKreiranjePolaznika.TxtBrojTelefona.Text))
            {
                isValid = false;
                UCKreiranjePolaznika.TxtBrojTelefona.BackColor = Color.LightCoral;
            }
            // Email validacija
            if (!IsValidEmail(UCKreiranjePolaznika.TxtEmail.Text))
            {
                isValid = false;
                UCKreiranjePolaznika.TxtEmail.BackColor = Color.LightCoral;
            }
            if (!isValid)
            {
                MessageBox.Show("Uneti podaci nisu validni. Proverite označena polja.");
                return;
            }

            // Validacija datuma - ne sme biti u budućnosti
            if (UCKreiranjePolaznika.DtDatumRodjenja.Value > DateTime.Now)
            {
                isValid = false;
                UCKreiranjePolaznika.DtDatumRodjenja.BackColor = Color.LightCoral;
            }

            if (string.IsNullOrEmpty(UCKreiranjePolaznika.TxtIme.Text) ||
                string.IsNullOrEmpty(UCKreiranjePolaznika.TxtPrezime.Text) ||
                string.IsNullOrEmpty(UCKreiranjePolaznika.TxtBrojTelefona.Text) ||
                string.IsNullOrEmpty(UCKreiranjePolaznika.TxtEmail.Text) ||
                UCKreiranjePolaznika.CmbPrebivalista.SelectedIndex == -1)
            {
                MessageBox.Show("Niste uneli sve podatke");
                return;
            }

            Polaznik polaznik = new Polaznik
            {
                Ime = UCKreiranjePolaznika.TxtIme.Text,
                Prezime = UCKreiranjePolaznika.TxtPrezime.Text,
                BrojTelefona = UCKreiranjePolaznika.TxtBrojTelefona.Text,
                Email = UCKreiranjePolaznika.TxtEmail.Text,
                DatumRodjenja = UCKreiranjePolaznika.DtDatumRodjenja.Value,
                Prebivaliste = UCKreiranjePolaznika.CmbPrebivalista.SelectedItem as Prebivaliste
            };

            // provera duplikata pre slanja zahteva
            try
            {
                Odgovor odgProvera = Komunikacija.Instance.VratiPolaznike();
                List<Polaznik> svi = Komunikacija.Instance.jns.ReadType<List<Polaznik>>(odgProvera.Podatak);
                
                bool postoji = false;
                foreach (Polaznik p in svi)
                {
                    if (polaznik.Ime == p.Ime && polaznik.Prezime == p.Prezime && polaznik.BrojTelefona == p.BrojTelefona && 
                        polaznik.DatumRodjenja.Date == p.DatumRodjenja.Date && 
                        polaznik.Prebivaliste?.IdPrebivaliste == p.Prebivaliste?.IdPrebivaliste)
                    {
                        MessageBox.Show("Polaznik sa istim podacima već postoji u bazi.");
                        return;
                    }

                }
            }
            catch { /* u slučaju greške u proveri nastavljamo sa čuvanjem */ }

            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.ZapamtiPolaznika(polaznik);
                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti polaznika\n");
                    return;
                }

                MessageBox.Show($"Sistem je zapamtio polaznika");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            // Uklanja sve karaktere osim brojeva
            string cleanNumber = phoneNumber.Replace("+", "")
                                           .Replace("-", "")
                                           .Replace(" ", "")
                                           .Replace("(", "")
                                           .Replace(")", "");

            // Proverava da li su svi preostali karakteri brojevi
            if (!cleanNumber.All(char.IsDigit))
                return false;

            // Proverava da li ima najmanje 7 cifara (minimum za telefon)
            return cleanNumber.Length >= 7 && cleanNumber.Length <= 15;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Prosta validacija email formata
            return email.Contains("@") && 
                   email.Contains(".") && 
                   email.IndexOf("@") > 0 && 
                   email.IndexOf("@") < email.Length - 1 &&
                   email.LastIndexOf(".") > email.IndexOf("@");
        }
    }
}

