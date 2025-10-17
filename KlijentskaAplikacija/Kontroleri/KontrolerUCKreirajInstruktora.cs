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
    public class KontrolerUCKreirajInstruktora
    {
        public UCKreiranjeInstruktora UCKreiranjeInstruktora { get; set; }

        public UCKreiranjeInstruktora NapraviUC()
        {
            UCKreiranjeInstruktora = new UCKreiranjeInstruktora();
            UCKreiranjeInstruktora.BtnZapamti.Click += BtnZapamti_Click;
            UCKreiranjeInstruktora.Dock = DockStyle.Fill;
            return UCKreiranjeInstruktora;
        }

        private void BtnZapamti_Click(object? sender, EventArgs e)
        {

            bool ok = true;

            // helper za validaciju
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            // prazna polja
            if (string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtIme.Text) ||
                string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtPrezime.Text) ||
                string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtBrojTelefona.Text) ||
                string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtKorisnickoIme.Text) ||
                string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtEmail.Text) ||
                string.IsNullOrEmpty(UCKreiranjeInstruktora.TxtSifra.Text))
            {
                MessageBox.Show("Niste uneli sve podatke");
                return;
            }

            // Ime
            if (!SamoSlova(UCKreiranjeInstruktora.TxtIme.Text))
            {
                ok = false;
                UCKreiranjeInstruktora.TxtIme.BackColor = Color.LightCoral;
            }

            // Prezime
            if (!SamoSlova(UCKreiranjeInstruktora.TxtPrezime.Text))
            {
                ok = false;
                UCKreiranjeInstruktora.TxtPrezime.BackColor = Color.LightCoral;
            }

            // Korisnicko ime
            if (!SamoSlova(UCKreiranjeInstruktora.TxtKorisnickoIme.Text))
            {
                ok = false;
                UCKreiranjeInstruktora.TxtKorisnickoIme.BackColor = Color.LightCoral;
            }

            // Broj telefona – mora biti ceo broj
            /* if (!long.TryParse(UCKreiranjeInstruktora.TxtBrojTelefona.Text, out _)) // long da podrži i veće brojeve
             {
                 ok = false;
                 UCKreiranjeInstruktora.TxtBrojTelefona.BackColor = Color.LightCoral;
             }*/

            // Broj telefona – validacija za string format
            if (!IsValidPhoneNumber(UCKreiranjeInstruktora.TxtBrojTelefona.Text))
            {
                ok = false;
                UCKreiranjeInstruktora.TxtBrojTelefona.BackColor = Color.LightCoral;
            }
            if (!ok)
            {
                MessageBox.Show("Podaci nisu u ispravnom formatu.");
                return;
            }


            Instruktor instruktor = new Instruktor
            {
                Ime = UCKreiranjeInstruktora.TxtIme.Text,
                Prezime = UCKreiranjeInstruktora.TxtPrezime.Text,
                BrojTelefona =UCKreiranjeInstruktora.TxtBrojTelefona.Text,
                Email =UCKreiranjeInstruktora.TxtEmail.Text,
                KorisnickoIme = UCKreiranjeInstruktora.TxtKorisnickoIme.Text,
                Sifra = UCKreiranjeInstruktora.TxtSifra.Text, 
            };

            // provera duplikata pre slanja zahteva
            try
            {
                Odgovor odgProvera = Komunikacija.Instance.VratiInstruktore();
                List<Instruktor> svi = Komunikacija.Instance.jns.ReadType<List<Instruktor>>(odgProvera.Podatak);
                bool postoji = false;
                foreach (Instruktor i in svi)
                {
                    if(instruktor.Ime==i.Ime && instruktor.Prezime==i.Prezime && instruktor.BrojTelefona==i.BrojTelefona
                        &&instruktor.Email==i.Email && instruktor.KorisnickoIme == i.KorisnickoIme)
                    {
                        MessageBox.Show("Instruktor sa istim podacima već postoji u bazi.");
                        return;
                    }

                  
                }
                
            }
            catch { /* u slučaju greške u proveri nastavljamo sa čuvanjem */ }

            Odgovor o = new Odgovor();

            try
            {
                o = Komunikacija.Instance.ZapamtiInstruktora(instruktor);
                if (o.IsSuccessful)
                {
                    MessageBox.Show("Uspesno sacuvan instruktor");
                }
                else
                {
                    MessageBox.Show("Nije uspesno sacuvan instruktor");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska: " + ex.Message);
                return;
            }


        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            // Uklanja sve dozvoljene karaktere osim brojeva
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
    }
}

