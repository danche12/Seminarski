using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija.Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.Kontroleri
{

    public class KontrolerUCUbaciSertifikatZaInstruktora
    {
        UCUbaciSertifikatZaInstruktora ucUbaciSertifikatZaInstruktora;
        public UCUbaciSertifikatZaInstruktora NapraviUC()
        {
            ucUbaciSertifikatZaInstruktora = new UCUbaciSertifikatZaInstruktora();
            PopuniPodatke();
            ucUbaciSertifikatZaInstruktora.BtnDodaj.Click += BtnDodajSertifikat_Click;
            return ucUbaciSertifikatZaInstruktora;
        }

        private void BtnDodajSertifikat_Click(object? sender, EventArgs e)
        {
            if (ucUbaciSertifikatZaInstruktora.CmbInstruktor.SelectedItem == null ||
                ucUbaciSertifikatZaInstruktora.CmbSertifikat.SelectedItem == null ||
                ucUbaciSertifikatZaInstruktora.DatumIzdavanja.Value > DateTime.Now)
            {
                MessageBox.Show("Sistem ne moze da zapamti sertifikat");
                return;
            }
            Instruktor i = (Instruktor)ucUbaciSertifikatZaInstruktora.CmbInstruktor.SelectedItem;
            Sertifikat s = (Sertifikat)ucUbaciSertifikatZaInstruktora.CmbSertifikat.SelectedItem;

            DateTime datum = ucUbaciSertifikatZaInstruktora.DatumIzdavanja.Value;

            InstruktorSertifikat ins = new InstruktorSertifikat()
            {
                Instruktor = i,
                Sertifikat = s,
                DatumIzdavanja = datum
            };


            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.UbaciSertifikatZaInstruktora(ins);
                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti sertifikat za instruktora\n");
                    return;
                }

                MessageBox.Show($"Sistem je zapamtio sertifikat za instruktora");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " +ex.Message);
                return;
            }
        }
        private void PopuniPodatke()
        {

            ucUbaciSertifikatZaInstruktora.CmbInstruktor.DropDownStyle = ComboBoxStyle.DropDownList;
            ucUbaciSertifikatZaInstruktora.CmbSertifikat.DropDownStyle = ComboBoxStyle.DropDownList;

            Odgovor odgovor;


            odgovor = Komunikacija.Instance.VratiInstruktore();


            if (!odgovor.IsSuccessful)
            {
                MessageBox.Show($"Sistem ne moze da ucita instruktore\n");
                return;
            }


            string jsonString = odgovor.Podatak.ToString();
            List<Instruktor> instruktori = JsonSerializer.Deserialize<List<Instruktor>>(jsonString);
            ucUbaciSertifikatZaInstruktora.CmbInstruktor.DataSource = instruktori;
            ucUbaciSertifikatZaInstruktora.CmbInstruktor.SelectedIndex = -1;
            

            Odgovor odgovor2;

            odgovor2 = Komunikacija.Instance.VratiSertifikate();


            if (!odgovor2.IsSuccessful)
            {
                MessageBox.Show($"Sistem ne moze da ucita sertifikate\n");
                return;
            }


            string jsonString2 = odgovor2.Podatak.ToString();
            List<Sertifikat> sertifikati = JsonSerializer.Deserialize<List<Sertifikat>>(jsonString2);
            ucUbaciSertifikatZaInstruktora.CmbSertifikat.DataSource = sertifikati;
            ucUbaciSertifikatZaInstruktora.CmbSertifikat.SelectedIndex = -1;
        }
    }
}
