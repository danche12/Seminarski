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
    public class KontrolerUCUbaciSertifikat
    {
        public UCUbaciSertifikat UCUbaciSertifikat { get; set; }

        public UCUbaciSertifikat NapraviUC()
        {
            UCUbaciSertifikat = new UCUbaciSertifikat();

            UCUbaciSertifikat.BtnZapamti.Click += BtnZapamti_Click;
            return UCUbaciSertifikat;
        }

        private void BtnZapamti_Click(object? sender, EventArgs e)
        {
            bool ok = true;

            // helper za validaciju - dozvoljava slova, brojeve i osnovne interpunkcije
            bool SamoSlova(string s) => s.All(ch => char.IsLetterOrDigit(ch) || ch == ' ' || ch == '-' || ch == '–' || ch == '—' || ch == '.' || ch == ',' || ch == '(' || ch == ')');

            // prazna polja
            if (string.IsNullOrEmpty(UCUbaciSertifikat.TxtNaziv.Text) ||
                string.IsNullOrEmpty(UCUbaciSertifikat.TxtInstitucija.Text))
            {
                MessageBox.Show("Niste uneli sve podatke");
                return;
            }

            // Ime
            if (!SamoSlova(UCUbaciSertifikat.TxtNaziv.Text))
            {
                ok = false;
                UCUbaciSertifikat.TxtNaziv.BackColor = Color.LightCoral;
            }

            // Prezime
            if (!SamoSlova(UCUbaciSertifikat.TxtInstitucija.Text))
            {
                ok = false;
                UCUbaciSertifikat.TxtInstitucija.BackColor = Color.LightCoral;
            }
            if (!ok)
            {
                MessageBox.Show("Podaci nisu u ispravnom formatu.");
                return;
            }
            Sertifikat s = new Sertifikat
            {
                Naziv = UCUbaciSertifikat.TxtNaziv.Text,
                Institucija = UCUbaciSertifikat.TxtInstitucija.Text
            };

            // provera duplikata pre slanja zahteva
            try
            {
                Odgovor odgProvera = Komunikacija.Instance.VratiSertifikate();
                List<Sertifikat> svi = Komunikacija.Instance.jns.ReadType<List<Sertifikat>>(odgProvera.Podatak);
                bool postoji = false;
                foreach (Sertifikat sert in svi)
                {
                    if(s.Naziv == sert.Naziv && s.Institucija == sert.Institucija)
                    {
                        MessageBox.Show("Sistem ne moze da zapamti sertifikat");
                        return;
                    }
                }
            }
            catch { /* u slučaju greške u proveri nastavljamo sa čuvanjem */ }

            Odgovor o = new Odgovor();

            try
            {
                o = Komunikacija.Instance.UbaciSertifikat(s);
                if (o.IsSuccessful)
                {
                    MessageBox.Show("Sistem je zapamtio sertifikat");
                }
                else
                {
                    MessageBox.Show("Sistem nije zapamtio sertifikat");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska: " + ex.Message);
                return;
            }

        }
    }
}
