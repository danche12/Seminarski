namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCKreiranjePolaznika
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtBrojTelefona = new TextBox();
            txtEmail = new TextBox();
            btnZapamti = new Button();
            cmbPrebivalista = new ComboBox();
            dtDatumRodjenja = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(258, 58);
            label1.Name = "label1";
            label1.Size = new Size(192, 23);
            label1.TabIndex = 0;
            label1.Text = "KREIRANJE POLAZNIKA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 114);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Ime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(195, 167);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Prezime:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 214);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 3;
            label4.Text = "Broj telefona:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(196, 320);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 4;
            label5.Text = "Datum rođenja:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(196, 367);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 5;
            label6.Text = "Prebivalište:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(196, 267);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 5;
            label7.Text = "Email:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(296, 114);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(200, 23);
            txtIme.TabIndex = 6;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(296, 164);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(200, 23);
            txtPrezime.TabIndex = 7;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(296, 214);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(200, 23);
            txtBrojTelefona.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(296, 264);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            // 
            // btnZapamti
            // 
            btnZapamti.BackColor = Color.RosyBrown;
            btnZapamti.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZapamti.ForeColor = SystemColors.ButtonHighlight;
            btnZapamti.Location = new Point(194, 425);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(302, 49);
            btnZapamti.TabIndex = 11;
            btnZapamti.Text = "ZAPAMTI";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // cmbPrebivalista
            // 
            cmbPrebivalista.FormattingEnabled = true;
            cmbPrebivalista.Location = new Point(296, 364);
            cmbPrebivalista.Name = "cmbPrebivalista";
            cmbPrebivalista.Size = new Size(200, 23);
            cmbPrebivalista.TabIndex = 12;
            // 
            // dtDatumRodjenja
            // 
            dtDatumRodjenja.Location = new Point(296, 314);
            dtDatumRodjenja.Name = "dtDatumRodjenja";
            dtDatumRodjenja.Size = new Size(200, 23);
            dtDatumRodjenja.TabIndex = 13;
            // 
            // UCKreiranjePolaznika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(dtDatumRodjenja);
            Controls.Add(cmbPrebivalista);
            Controls.Add(btnZapamti);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtEmail);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCKreiranjePolaznika";
            Size = new Size(666, 508);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtBrojTelefona;
        private TextBox txtEmail;
        private Button btnZapamti;
        private ComboBox cmbPrebivalista;
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
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public DateTimePicker DtDatumRodjenja { get => dtDatumRodjenja; set => dtDatumRodjenja = value; }
        public Button BtnZapamti { get => btnZapamti; set => btnZapamti = value; }

        public ComboBox CmbPrebivalista { get => cmbPrebivalista; set => cmbPrebivalista = value; }
    }
}
