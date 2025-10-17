namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCPretrazivanjePolaznika
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
            btnIzmeniPodatke = new Button();
            btnObrisiPolaznika = new Button();
            btnPretraziPolaznika = new Button();
            dataGridView1 = new DataGridView();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnIzmeniPodatke
            // 
            btnIzmeniPodatke.BackColor = Color.RosyBrown;
            btnIzmeniPodatke.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIzmeniPodatke.ForeColor = SystemColors.ButtonHighlight;
            btnIzmeniPodatke.Location = new Point(31, 430);
            btnIzmeniPodatke.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniPodatke.Name = "btnIzmeniPodatke";
            btnIzmeniPodatke.Size = new Size(512, 38);
            btnIzmeniPodatke.TabIndex = 17;
            btnIzmeniPodatke.Text = "IZMENI PODATKE O IZABRANOM POLAZNIKU";
            btnIzmeniPodatke.UseVisualStyleBackColor = false;
            // 
            // btnObrisiPolaznika
            // 
            btnObrisiPolaznika.BackColor = Color.RosyBrown;
            btnObrisiPolaznika.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnObrisiPolaznika.ForeColor = SystemColors.ButtonHighlight;
            btnObrisiPolaznika.Location = new Point(308, 185);
            btnObrisiPolaznika.Margin = new Padding(3, 2, 3, 2);
            btnObrisiPolaznika.Name = "btnObrisiPolaznika";
            btnObrisiPolaznika.Size = new Size(234, 31);
            btnObrisiPolaznika.TabIndex = 16;
            btnObrisiPolaznika.Text = "OBRIŠI POLAZNIKA";
            btnObrisiPolaznika.UseVisualStyleBackColor = false;
            // 
            // btnPretraziPolaznika
            // 
            btnPretraziPolaznika.BackColor = Color.RosyBrown;
            btnPretraziPolaznika.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPretraziPolaznika.ForeColor = SystemColors.ButtonHighlight;
            btnPretraziPolaznika.Location = new Point(31, 185);
            btnPretraziPolaznika.Margin = new Padding(3, 2, 3, 2);
            btnPretraziPolaznika.Name = "btnPretraziPolaznika";
            btnPretraziPolaznika.Size = new Size(244, 31);
            btnPretraziPolaznika.TabIndex = 15;
            btnPretraziPolaznika.Text = "PRETRAŽI";
            btnPretraziPolaznika.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 224);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(512, 196);
            dataGridView1.TabIndex = 14;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(90, 141);
            txtPrezime.Margin = new Padding(3, 2, 3, 2);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(178, 23);
            txtPrezime.TabIndex = 13;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(90, 100);
            txtIme.Margin = new Padding(3, 2, 3, 2);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(178, 23);
            txtIme.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 146);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 11;
            label3.Text = "Prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 103);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 10;
            label2.Text = "Ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(174, 45);
            label1.Name = "label1";
            label1.Size = new Size(240, 23);
            label1.TabIndex = 9;
            label1.Text = "PRETRAŽIVANJE POLAZNIKA";
            // 
            // UCPretrazivanjePolaznika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(btnIzmeniPodatke);
            Controls.Add(btnObrisiPolaznika);
            Controls.Add(btnPretraziPolaznika);
            Controls.Add(dataGridView1);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCPretrazivanjePolaznika";
            Size = new Size(570, 546);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIzmeniPodatke;
        private Button btnObrisiPolaznika;
        private Button btnPretraziPolaznika;
        private DataGridView dataGridView1;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDetaljiPolaznika;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public DataGridView DataGridView1 { get => dataGridView1; set => dataGridView1 = value; }
        public Button BtnPretraziPolaznika { get => btnPretraziPolaznika; set => btnPretraziPolaznika = value; }
        public Button BtnObrisiPolaznika { get => btnObrisiPolaznika; set => btnObrisiPolaznika = value; }
        public Button BtnDetaljiPolaznika { get => btnDetaljiPolaznika; set => btnDetaljiPolaznika = value; }
        public Button BtnIzmeniPodatke { get => btnIzmeniPodatke; set => btnIzmeniPodatke = value; }
    }
}
