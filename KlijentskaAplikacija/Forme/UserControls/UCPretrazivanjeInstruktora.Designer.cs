namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCPretrazivanjeInstruktora
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
            btnPretrazi = new Button();
            dataGridView1 = new DataGridView();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.RosyBrown;
            btnPretrazi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPretrazi.ForeColor = SystemColors.ButtonHighlight;
            btnPretrazi.Location = new Point(428, 125);
            btnPretrazi.Margin = new Padding(3, 2, 3, 2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(210, 52);
            btnPretrazi.TabIndex = 13;
            btnPretrazi.Text = "PRETRAŽI ";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(60, 200);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(578, 141);
            dataGridView1.TabIndex = 12;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(150, 154);
            txtPrezime.Margin = new Padding(3, 2, 3, 2);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(259, 23);
            txtPrezime.TabIndex = 11;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(149, 124);
            txtIme.Margin = new Padding(3, 2, 3, 2);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(259, 23);
            txtIme.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 154);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 124);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 8;
            label2.Text = "Ime:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(214, 54);
            label1.Name = "label1";
            label1.Size = new Size(253, 23);
            label1.TabIndex = 7;
            label1.Text = "PRETRAŽIVANJE INSTRUKTORA";
            // 
            // UCPretrazivanjeInstruktora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(btnPretrazi);
            Controls.Add(dataGridView1);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCPretrazivanjeInstruktora";
            Size = new Size(734, 438);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPretrazi;
        private DataGridView dataGridView1;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label3;
        private Label label2;
        private Label label1;
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public DataGridView DataGridView1 { get => dataGridView1; set => dataGridView1 = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
    }
}
