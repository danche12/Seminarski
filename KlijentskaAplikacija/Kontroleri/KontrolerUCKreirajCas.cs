using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerUCKreirajCas
    {
        public UCKreiranjeCasa UCKreiranjeCasa { get; set; }

        public UCKreiranjeCasa NapraviUC()
        {
            UCKreiranjeCasa = new UCKreiranjeCasa();

            // Popuni module
            var moduli = new List<string>
            {
                "Web dizajn",
                "Grafički dizajn",
                "Digitalni marketing",
                "Fotografija",
                "Video produkcija",
                "Mobile app razvoj"
            };
            UCKreiranjeCasa.CmbModul.DataSource = moduli;
            UCKreiranjeCasa.CmbModul.SelectedIndex = -1;

            UCKreiranjeCasa.BtnZapamti.Click += BtnZapamti_Click;
            return UCKreiranjeCasa;
        }

        private void BtnZapamti_Click(object? sender, EventArgs e)
        {
            string naziv = UCKreiranjeCasa.TxtTemaCasa.Text.Trim();

            // dozvoljena su samo slova, razmak i '-'
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            if (string.IsNullOrEmpty(naziv) || !SamoSlova(naziv))
            {
                UCKreiranjeCasa.TxtTemaCasa.BackColor = Color.LightCoral;
                MessageBox.Show("Tema casa mora sadržati samo slova.");
                return;
            }
            if (string.IsNullOrEmpty(UCKreiranjeCasa.TxtTemaCasa.Text) ||
                string.IsNullOrEmpty(UCKreiranjeCasa.TxtCena.Text) ||
                (!UCKreiranjeCasa.RadioButton1.Checked &&
                 !UCKreiranjeCasa.RadioButton2.Checked &&
                 !UCKreiranjeCasa.RadioButton3.Checked) ||
                UCKreiranjeCasa.CmbModul.SelectedIndex < 0)
                        {
                MessageBox.Show("Niste uneli sve podatke (uključujući modul)");
                return;
            }
            // Validacija cene
            if (!IsValidPrice(UCKreiranjeCasa.TxtCena.Text))
            {
                UCKreiranjeCasa.TxtCena.BackColor = Color.LightCoral;
                MessageBox.Show("Cena mora biti pozitivan broj.");
                return;
            }
            Cas cas = new Cas
            {
                TemaCasa = UCKreiranjeCasa.TxtTemaCasa.Text,
                Modul = UCKreiranjeCasa.CmbModul.SelectedItem?.ToString()
            };
            if (UCKreiranjeCasa.RadioButton1.Checked)
            {
                cas.TrajanjeCasa = 45;
            }
            else if (UCKreiranjeCasa.RadioButton2.Checked)
            {
                cas.TrajanjeCasa = 60;
            }
            else if (UCKreiranjeCasa.RadioButton3.Checked)
            {
                cas.TrajanjeCasa = 90;
            }
            cas.CenaCasa = double.Parse(UCKreiranjeCasa.TxtCena.Text);

            Odgovor o = new Odgovor();

            try
            {
                o = Komunikacija.Instance.ZapamtiCas(cas);
                if (o.IsSuccessful)
                {
                    MessageBox.Show("Uspesno sacuvan cas");
                }
                else
                {
                    MessageBox.Show("Nije uspesno sacuvan cas");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }
        private bool IsValidPrice(string cenaText)
        {
            if (string.IsNullOrEmpty(cenaText))
                return false;

            // Pokušava da parsira kao double
            if (!double.TryParse(cenaText, out double cena))
                return false;

            // Proverava da li je pozitivan broj
            return cena > 0;
        }
    }
}
