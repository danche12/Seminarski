namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCKreiranjeInstruktora
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
            btnZapamti = new Button();
            txtBrojTelefona = new TextBox();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            txtSifra = new TextBox();
            txtEmail = new TextBox();
            txtKorisnickoIme = new TextBox();
            SuspendLayout();
            // 
            // btnZapamti
            // 
            btnZapamti.BackColor = Color.RosyBrown;
            btnZapamti.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZapamti.ForeColor = SystemColors.ButtonHighlight;
            btnZapamti.Location = new Point(220, 426);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(302, 42);
            btnZapamti.TabIndex = 23;
            btnZapamti.Text = "ZAPAMTI";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(322, 212);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(200, 23);
            txtBrojTelefona.TabIndex = 22;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(322, 162);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(200, 23);
            txtPrezime.TabIndex = 21;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(322, 112);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(200, 23);
            txtIme.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(220, 325);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 19;
            label6.Text = "Korisničko ime:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 267);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 18;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 212);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 17;
            label4.Text = "Broj telefona:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 165);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 16;
            label3.Text = "Prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 112);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 15;
            label2.Text = "Ime:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 39);
            label1.Name = "label1";
            label1.Size = new Size(213, 23);
            label1.TabIndex = 14;
            label1.Text = "KREIRANJE INSTRUKTORA";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(223, 382);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 26;
            label7.Text = "Šifra:";
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(322, 379);
            txtSifra.Name = "txtSifra";
            txtSifra.Size = new Size(200, 23);
            txtSifra.TabIndex = 27;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(322, 264);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 28;
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(322, 322);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(200, 23);
            txtKorisnickoIme.TabIndex = 29;
            // 
            // UCKreiranjeInstruktora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(txtKorisnickoIme);
            Controls.Add(txtEmail);
            Controls.Add(txtSifra);
            Controls.Add(label7);
            Controls.Add(btnZapamti);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCKreiranjeInstruktora";
            Size = new Size(654, 609);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnZapamti;
        private TextBox txtBrojTelefona;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private TextBox txtSifra;
        private TextBox txtEmail;
        private TextBox txtKorisnickoIme;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label Label5 { get => label5; set => label5 = value; }
        public Label Label6 { get => label6; set => label6 = value; }
        public Label Label7 { get => label7; set => label7 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtBrojTelefona { get => txtBrojTelefona; set => txtBrojTelefona = value; }
        public TextBox TxtKorisnickoIme { get => txtKorisnickoIme; set => txtKorisnickoIme = value; }
        public TextBox TxtSifra { get => txtSifra; set => txtSifra = value; }
        public TextBox TxtEmail { get => txtEmail; set => TxtEmail = value; }
        public Button BtnZapamti { get => btnZapamti; set => btnZapamti = value; }
    }
}
