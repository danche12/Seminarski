namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class PretraziEvidencijuKursa
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
            dgvEvidencije = new DataGridView();
            btnPretrazi = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEvidencije).BeginInit();
            SuspendLayout();
            // 
            // btnIzmeni
            // 
            btnIzmeni.BackColor = Color.RosyBrown;
            btnIzmeni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIzmeni.ForeColor = SystemColors.ButtonHighlight;
            btnIzmeni.Location = new Point(231, 321);
            btnIzmeni.Margin = new Padding(3, 2, 3, 2);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(201, 37);
            btnIzmeni.TabIndex = 17;
            btnIzmeni.Text = "IZMENI";
            btnIzmeni.UseVisualStyleBackColor = false;
            // 
            // dgvEvidencije
            // 
            dgvEvidencije.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEvidencije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvidencije.Location = new Point(56, 152);
            dgvEvidencije.Margin = new Padding(3, 2, 3, 2);
            dgvEvidencije.Name = "dgvEvidencije";
            dgvEvidencije.RowHeadersWidth = 51;
            dgvEvidencije.Size = new Size(543, 141);
            dgvEvidencije.TabIndex = 16;
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.RosyBrown;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPretrazi.ForeColor = SystemColors.ButtonHighlight;
            btnPretrazi.Location = new Point(458, 106);
            btnPretrazi.Margin = new Padding(3, 2, 3, 2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(141, 26);
            btnPretrazi.TabIndex = 15;
            btnPretrazi.Text = "PRETRAŽI";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(244, 109);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 14;
            label4.Text = "Prezime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 110);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 13;
            label3.Text = "Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 76);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 12;
            label2.Text = "Pretraga po instruktoru";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(312, 106);
            txtPrezime.Margin = new Padding(3, 2, 3, 2);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(120, 23);
            txtPrezime.TabIndex = 11;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(93, 106);
            txtIme.Margin = new Padding(3, 2, 3, 2);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 23);
            txtIme.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(209, 28);
            label1.Name = "label1";
            label1.Size = new Size(256, 23);
            label1.TabIndex = 9;
            label1.Text = "PRETRAGA EVIDENCIJE KURSA";
            // 
            // PretraziEvidencijuKursa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(676, 393);
            Controls.Add(btnIzmeni);
            Controls.Add(dgvEvidencije);
            Controls.Add(btnPretrazi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "PretraziEvidencijuKursa";
            Text = "PretraziEvidencijuKursa";
            Load += PretraziEvidencijuKursa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvidencije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIzmeni;
        private DataGridView dgvEvidencije;
        private Button btnPretrazi;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label1;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public DataGridView DgvEvidencije { get => dgvEvidencije; set => dgvEvidencije = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
    }
}