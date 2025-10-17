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
    public class KontrolerUCPretraziPolaznika
    {
        public UCPretrazivanjePolaznika UCPretrazivanjePolaznika { get; set; }

        public UCPretrazivanjePolaznika NapraviUC()
        {
            UCPretrazivanjePolaznika = new UCPretrazivanjePolaznika();
            PopuniPodatke();
            UCPretrazivanjePolaznika.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretrazivanjePolaznika.BtnPretraziPolaznika.Click += BtnPretraziPolaznika;
            UCPretrazivanjePolaznika.BtnObrisiPolaznika.Click += BtnObrisiPolaznika;
            UCPretrazivanjePolaznika.BtnIzmeniPodatke.Click += BtnIzmeniPodatke_Click;

            return UCPretrazivanjePolaznika;
        }

        private void BtnIzmeniPodatke_Click(object? sender, EventArgs e)
        {
            Odgovor odgovor;

            if (UCPretrazivanjePolaznika.DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Niste selektovali polaznika za izmenu");
                return;
            }

            try
            {
                Polaznik polaznik = new Polaznik();
                var row = UCPretrazivanjePolaznika.DataGridView1.SelectedRows[0];
                polaznik = (Polaznik)row.DataBoundItem;

                KontrolerDetaljiPolaznika kontroler = new KontrolerDetaljiPolaznika();
                DetaljiPolaznika frm = kontroler.NapraviFormu(polaznik);
                frm.ShowDialog();
                PopuniPodatke();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }

        private void PopuniPodatke()
        {
            VratiPolaznike();
        }
        public void BtnPretraziPolaznika(object sender, EventArgs e)
        {
            UCPretrazivanjePolaznika.TxtIme.BackColor = Color.White;
            UCPretrazivanjePolaznika.TxtPrezime.BackColor = Color.White;

            bool ok = true;

            string ime = UCPretrazivanjePolaznika.TxtIme.Text.Trim();
            string prezime = UCPretrazivanjePolaznika.TxtPrezime.Text.Trim();

            // dozvoljena su samo slova (+ razmak i -)
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            if (ime.Length > 0 && !SamoSlova(ime))
            {
                ok = false;
                UCPretrazivanjePolaznika.TxtIme.BackColor = Color.LightCoral;
            }
            if (prezime.Length > 0 && !SamoSlova(prezime))
            {
                ok = false;
                UCPretrazivanjePolaznika.TxtPrezime.BackColor = Color.LightCoral;
            }

            if (!ok)
            {
                MessageBox.Show("Ime i prezime moraju sadržati samo slova.");
                return;
            }


            if (string.IsNullOrEmpty(UCPretrazivanjePolaznika.TxtIme.Text) ||
                string.IsNullOrEmpty(UCPretrazivanjePolaznika.TxtPrezime.Text))
            {
                MessageBox.Show("Niste uneli sve podatke");
                return;
            }
            string[] imeiprezime = new string[2];
            imeiprezime[0] = UCPretrazivanjePolaznika.TxtIme.Text;
            imeiprezime[1] = UCPretrazivanjePolaznika.TxtPrezime.Text;

            Odgovor odgovor = Komunikacija.Instance.PretraziPolaznika(imeiprezime);

            string jsonString = odgovor.Podatak.ToString();
            List<Polaznik> polaznici = JsonSerializer.Deserialize<List<Polaznik>>(jsonString);

            if (polaznici == null || polaznici.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da nađe polaznika");
                UCPretrazivanjePolaznika.DataGridView1.DataSource = new BindingList<Polaznik>();
                return;
            }

            MessageBox.Show("Sistem je uspeo da vrati polaznika");
            UCPretrazivanjePolaznika.DataGridView1.DataSource = null;
            UCPretrazivanjePolaznika.DataGridView1.DataSource = polaznici;
            UCPretrazivanjePolaznika.DataGridView1.Columns[0].Visible = false;
        }


        public void BtnObrisiPolaznika(object sender, EventArgs e)
        {
            UCPretrazivanjePolaznika.TxtIme.BackColor = Color.White;
            UCPretrazivanjePolaznika.TxtPrezime.BackColor = Color.White;

            bool ok = true;

            string ime = UCPretrazivanjePolaznika.TxtIme.Text.Trim();
            string prezime = UCPretrazivanjePolaznika.TxtPrezime.Text.Trim();

            // dozvoljena su samo slova (+ razmak i -)
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            if (ime.Length > 0 && !SamoSlova(ime))
            {
                ok = false;
                UCPretrazivanjePolaznika.TxtIme.BackColor = Color.LightCoral;
            }
            if (prezime.Length > 0 && !SamoSlova(prezime))
            {
                ok = false;
                UCPretrazivanjePolaznika.TxtPrezime.BackColor = Color.LightCoral;
            }

            if (!ok)
            {
                MessageBox.Show("Ime i prezime moraju sadržati samo slova.");
                return;
            }


            Odgovor odgovor;

            if (UCPretrazivanjePolaznika.DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da izbrise polaznika");
                return;
            }

            try
            {
                Polaznik polaznik = new Polaznik();
                var row = UCPretrazivanjePolaznika.DataGridView1.SelectedRows[0];
                polaznik = (Polaznik)row.DataBoundItem;

                odgovor = Komunikacija.Instance.ObrisiPolaznika(polaznik);

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da izbrise polaznika\n");
                    return;
                }
                PopuniPodatke();
                MessageBox.Show($"Sistem je izbrisao podatke o polazniku");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }

        }

        private void VratiPolaznike()// ovde mi ne radi nece samo u dgv da ispise tog pretrazenog polaznika
        {
            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.VratiPolaznike();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da vrati polaznike\n");
                    return;
                }


                string jsonString = odgovor.Podatak.ToString();

                // Deserijalizuj u List<Polaznik>
                List<Polaznik> polaznici = JsonSerializer.Deserialize<List<Polaznik>>(jsonString);

                // Postavi podatke u DataGridView
                UCPretrazivanjePolaznika.DataGridView1.AllowUserToAddRows = false; // nema praznog reda
                UCPretrazivanjePolaznika.DataGridView1.ReadOnly = true;            // (opciono) samo prikaz
                UCPretrazivanjePolaznika.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                UCPretrazivanjePolaznika.DataGridView1.MultiSelect = false;
                UCPretrazivanjePolaznika.DataGridView1.DataSource = new BindingList<Polaznik>(polaznici);
                UCPretrazivanjePolaznika.DataGridView1.Columns[0].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }
    }
}
