namespace KlijentskaAplikacija.Forme
{
    partial class DetaljiPolaznika
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIzmeni = new Button();
            cmbPrebivalista = new ComboBox();
            txtBrojTelefona = new TextBox();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            dtDatumRodjenja = new DateTimePicker();
            SuspendLayout();
            // 
            // btnIzmeni
            // 
            btnIzmeni.BackColor = Color.RosyBrown;
            btnIzmeni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIzmeni.ForeColor = SystemColors.ButtonHighlight;
            btnIzmeni.Location = new Point(73, 313);
            btnIzmeni.Margin = new Padding(3, 2, 3, 2);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(312, 33);
            btnIzmeni.TabIndex = 20;
            btnIzmeni.Text = "POTVRDI IZMENE";
            btnIzmeni.UseVisualStyleBackColor = false;
            // 
            // cmbPrebivalista
            // 
            cmbPrebivalista.FormattingEnabled = true;
            cmbPrebivalista.Location = new Point(181, 258);
            cmbPrebivalista.Margin = new Padding(3, 2, 3, 2);
            cmbPrebivalista.Name = "cmbPrebivalista";
            cmbPrebivalista.Size = new Size(204, 23);
            cmbPrebivalista.TabIndex = 19;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(181, 181);
            txtBrojTelefona.Margin = new Padding(3, 2, 3, 2);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(204, 23);
            txtBrojTelefona.TabIndex = 18;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(181, 143);
            txtPrezime.Margin = new Padding(3, 2, 3, 2);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(204, 23);
            txtPrezime.TabIndex = 17;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(181, 110);
            txtIme.Margin = new Padding(3, 2, 3, 2);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(204, 23);
            txtIme.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 261);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 15;
            label5.Text = "Prebivališta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 184);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 14;
            label4.Text = "Broj Telefona";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 146);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 13;
            label3.Text = "Prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 111);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 12;
            label2.Text = "Ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 47);
            label1.Name = "label1";
            label1.Size = new Size(167, 23);
            label1.TabIndex = 11;
            label1.Text = "DETALJI POLAZNIKA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 228);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 21;
            label6.Text = "Datum rođenja:";
            // 
            // dtDatumRodjenja
            // 
            dtDatumRodjenja.Location = new Point(181, 220);
            dtDatumRodjenja.Name = "dtDatumRodjenja";
            dtDatumRodjenja.Size = new Size(204, 23);
            dtDatumRodjenja.TabIndex = 22;
            // 
            // DetaljiPolaznika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(483, 450);
            Controls.Add(dtDatumRodjenja);
            Controls.Add(label6);
            Controls.Add(btnIzmeni);
            Controls.Add(cmbPrebivalista);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DetaljiPolaznika";
            Text = "DetaljiPolaznika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIzmeni;
        private ComboBox cmbPrebivalista;
        private TextBox txtBrojTelefona;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private DateTimePicker dtDatumRodjenja;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label Label5 { get => label5; set => label5 = value; }
        public Label Label6 { get => label6; set => label6 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtBrojTelefona { get => txtBrojTelefona; set => txtBrojTelefona = value; }
        public ComboBox CmbPrebivalista { get => cmbPrebivalista; set => cmbPrebivalista = value; }
        public DateTimePicker DtDatumRodjenja { get => dtDatumRodjenja; set => dtDatumRodjenja = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
    }
}