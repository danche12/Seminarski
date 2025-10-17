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
    public class KontrolerUCPretraziCas
    {
        public UCPretrazivanjeCasa UCPretrazivanjeCasa { get; set; }

        public UCPretrazivanjeCasa NapraviUC()
        {
            UCPretrazivanjeCasa = new UCPretrazivanjeCasa();
            UCPretrazivanjeCasa.DataGridView1.AllowUserToAddRows = false;
            VratiCasove();
            UCPretrazivanjeCasa.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretrazivanjeCasa.BtnPretrazi.Click += BtnPretrazi_Click;
            return UCPretrazivanjeCasa;
        }

        private void BtnPretrazi_Click(object? sender, EventArgs e)
        {
            bool ok = true;

            string tema = UCPretrazivanjeCasa.TxtTema.Text;

            // helper: samo slova, razmak i crtica
            bool SamoSlova(string s) => s.All(ch => char.IsLetter(ch) || ch == ' ' || ch == '-');

            // provera praznih polja
            if (string.IsNullOrEmpty(tema))
            {
                MessageBox.Show("Morate uneti naziv casa.");
                return;
            }

            // validacija naziva
            if (!SamoSlova(tema))
            {
                ok = false;
                UCPretrazivanjeCasa.TxtTema.BackColor = Color.LightCoral;
            }

            if (!ok)
            {
                MessageBox.Show("Tema casa mora sadrzati samo slova.");
                return;
            }


            Cas cas = new Cas()
            {
                TemaCasa = UCPretrazivanjeCasa.TxtTema.Text
            };
            Odgovor odgovor = Komunikacija.Instance.PretraziCas(cas);

            string jsonString = odgovor.Podatak.ToString();

            // Deserijalizuj u List<Polaznik>
            List<Cas> casovi = JsonSerializer.Deserialize<List<Cas>>(jsonString);
            if (casovi.Any(p => p.TemaCasa == tema))
            {
                MessageBox.Show("Sistem je uspeo da vrati cas");

                var dgv = UCPretrazivanjeCasa.DataGridView1;

                // UX
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;

                // >>> Samo Naziv i Duzina <<<
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Clear();

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TemaCasa",
                    HeaderText = "Tema casa",
                    DataPropertyName = "TemaCasa",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CenaCasa",
                    HeaderText = "Cena casa (RSD)",
                    DataPropertyName = "CenaCasa",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N2"  // Formatira kao broj sa 2 decimalna mesta
                    }
                });

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TrajanjeCasa",
                    HeaderText = "Trajanje casa (minuti)",
                    DataPropertyName = "TrajanjeCasa",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });

                // bind
                dgv.DataSource = new BindingList<Cas>(casovi);



            }
            else
            {
                MessageBox.Show("Sistem ne moze da vrati cas");
            }

        }

        private void VratiCasove()
        {
            Odgovor odgovor = new Odgovor();

            try
            {
                odgovor = Komunikacija.Instance.VratiCasove();

                if (!odgovor.IsSuccessful)
                {
                    MessageBox.Show($"Sistem ne moze da vrati casove\n");
                    return;
                }

                string jsonString = odgovor.Podatak.ToString();

                // Deserijalizuj u List<Kurs>
                List<Cas> kursevi = JsonSerializer.Deserialize<List<Cas>>(jsonString);

                // Postavi podatke u DataGridView
                UCPretrazivanjeCasa.DataGridView1.DataSource = new BindingList<Cas>(kursevi);
                var dgv = UCPretrazivanjeCasa.DataGridView1;
                foreach (DataGridViewColumn col in dgv.Columns)
                    col.Visible = col.DataPropertyName == "TemaCasa" ||
                                  col.DataPropertyName == "CenaCasa" ||
                                  col.DataPropertyName == "TrajanjeCasa";
                dgv.Columns["TemaCasa"].HeaderText = "Tema casa";
                dgv.Columns["TrajanjeCasa"].HeaderText = "Dužina trajanja casa u minutima";
                dgv.Columns["CenaCasa"].HeaderText = "Cena casa u dinarima";
                UCPretrazivanjeCasa.DataGridView1.Refresh();
  

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }
    }
}
