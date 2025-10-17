using Common.Domen;
using Common.Transfer;
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
    public class KontrolerUCPretraziInstruktora
    {
        public UCPretrazivanjeInstruktora UCPretrazivanjeInstruktora { get; set; }

        public UCPretrazivanjeInstruktora NapraviUC()
        {
            UCPretrazivanjeInstruktora = new UCPretrazivanjeInstruktora();
            PopuniPodatke();
            UCPretrazivanjeInstruktora.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretrazivanjeInstruktora.BtnPretrazi.Click += BtnPretrazi_Click;
            return UCPretrazivanjeInstruktora;
        }

        private void BtnPretrazi_Click(object? sender, EventArgs e)
        {

            bool ok = true;

            string ime = UCPretrazivanjeInstruktora.TxtIme.Text.Trim();
            string prezime = UCPretrazivanjeInstruktora.TxtPrezime.Text.Trim();

            // helper: samo slova, razmak i crtica
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            // provera praznih polja
            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime))
            {
                MessageBox.Show("Morate uneti i ime i prezime.");
                return;
            }

            // validacija imena
            if (!SamoSlova(ime))
            {
                ok = false;
                UCPretrazivanjeInstruktora.TxtIme.BackColor = Color.LightCoral;
            }

            // validacija prezimena
            if (!SamoSlova(prezime))
            {
                ok = false;
                UCPretrazivanjeInstruktora.TxtPrezime.BackColor = Color.LightCoral;
            }

            if (!ok)
            {
                MessageBox.Show("Ime i prezime moraju sadržati samo slova.");
                return;
            }
            string Ime = UCPretrazivanjeInstruktora.TxtIme.Text;
            string Prezime = UCPretrazivanjeInstruktora.TxtPrezime.Text;

            Instruktor instruktor = new Instruktor()
            {
                Ime = UCPretrazivanjeInstruktora.TxtIme.Text,
                Prezime = UCPretrazivanjeInstruktora.TxtPrezime.Text
            };
            Odgovor odgovor = Komunikacija.Instance.PretraziInstruktora(instruktor);

            string jsonString = odgovor.Podatak.ToString();

            // Deserijalizuj u List<Polaznik>
            List<Instruktor> instruktori = JsonSerializer.Deserialize<List<Instruktor>>(jsonString);
            if (instruktori.Any(p => p.Ime == Ime && p.Prezime == Prezime))
            {
                MessageBox.Show("Sistem je uspeo da vrati instruktora");

                UCPretrazivanjeInstruktora.DataGridView1.DataSource = null;
                UCPretrazivanjeInstruktora.DataGridView1.DataSource = instruktori;
                UCPretrazivanjeInstruktora.DataGridView1.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Sistem ne moze da vrati instruktora");
            }
        }

        private void PopuniPodatke()
        {
            VratiInstruktore();
        }

        private void VratiInstruktore()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.VratiInstruktore();
                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show("Sistem ne moze da vrati instruktore\n");
                    return;
                }

                var jsonString = odgovor.Podatak.ToString();

                var instruktori = JsonSerializer.Deserialize<List<Instruktor>>(
                    jsonString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var dgv = UCPretrazivanjeInstruktora.DataGridView1;

                // UX
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;

                // >>> Prikaži samo tražene kolone <<<
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Clear();

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Ime",
                    HeaderText = "Ime",
                    DataPropertyName = "Ime",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Prezime",
                    HeaderText = "Prezime",
                    DataPropertyName = "Prezime",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "BrojTelefona",
                    HeaderText = "Broj telefona",
                    DataPropertyName = "BrojTelefona",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Email",
                    HeaderText = "Email",
                    DataPropertyName = "Email",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "KorisnickoIme",
                    HeaderText = "Korisničko ime",
                    DataPropertyName = "KorisnickoIme",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });

                // Lozinka — maskira se preko CellFormatting eventa
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Sifra",
                    HeaderText = "Šifra",
                    DataPropertyName = "Sifra",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });

                // bind
                dgv.DataSource = new BindingList<Instruktor>(instruktori);

                // obezbedi da je event kačen samo jednom
                dgv.CellFormatting -= MaskLozinkaCellFormatting;
                dgv.CellFormatting += MaskLozinkaCellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void MaskLozinkaCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = UCPretrazivanjeInstruktora.DataGridView1;

            if (grid.Columns[e.ColumnIndex].DataPropertyName == "Sifra" && e.Value != null)
            {
                var len = e.Value.ToString()?.Length ?? 0;
                e.Value = new string('*', len);   // npr. "******"
                e.FormattingApplied = true;
            }
        }
    }
}
