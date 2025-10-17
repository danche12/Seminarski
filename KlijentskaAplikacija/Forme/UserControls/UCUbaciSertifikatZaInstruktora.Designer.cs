namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCUbaciSertifikatZaInstruktora
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
            btnDodaj = new Button();
            cmbSertifikat = new ComboBox();
            cmbInstruktor = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnDodaj
            // 
            btnDodaj.BackColor = Color.RosyBrown;
            btnDodaj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDodaj.ForeColor = SystemColors.ButtonHighlight;
            btnDodaj.Location = new Point(223, 185);
            btnDodaj.Margin = new Padding(3, 2, 3, 2);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(221, 45);
            btnDodaj.TabIndex = 15;
            btnDodaj.Text = "DODAJ SERTIFIKAT";
            btnDodaj.UseVisualStyleBackColor = false;
            // 
            // cmbSertifikat
            // 
            cmbSertifikat.FormattingEnabled = true;
            cmbSertifikat.Location = new Point(394, 69);
            cmbSertifikat.Margin = new Padding(3, 2, 3, 2);
            cmbSertifikat.Name = "cmbSertifikat";
            cmbSertifikat.Size = new Size(233, 23);
            cmbSertifikat.TabIndex = 13;
            // 
            // cmbInstruktor
            // 
            cmbInstruktor.FormattingEnabled = true;
            cmbInstruktor.Location = new Point(96, 69);
            cmbInstruktor.Margin = new Padding(3, 2, 3, 2);
            cmbInstruktor.Name = "cmbInstruktor";
            cmbInstruktor.Size = new Size(220, 23);
            cmbInstruktor.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 72);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 10;
            label3.Text = "Sertifikat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 72);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 9;
            label2.Text = "Instruktor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(253, 24);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 8;
            label1.Text = "UBACI SERTIFIKAT";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(192, 121);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(252, 23);
            dateTimePicker1.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 127);
            label5.Name = "label5";
            label5.Size = new Size(149, 15);
            label5.TabIndex = 17;
            label5.Text = "Datum izdavanja sertifikata";
            // 
            // UCUbaciSertifikat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(btnDodaj);
            Controls.Add(cmbSertifikat);
            Controls.Add(cmbInstruktor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCUbaciSertifikat";
            Size = new Size(682, 289);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDodaj;
        private ComboBox cmbSertifikat;
        private ComboBox cmbInstruktor;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label5;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        
        public ComboBox CmbInstruktor { get => cmbInstruktor; set => cmbInstruktor = value; }
        public ComboBox CmbSertifikat { get => cmbSertifikat; set => cmbSertifikat = value; }

        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public DateTimePicker DatumIzdavanja { get => dateTimePicker1; set => dateTimePicker1 = value; }
    }
}
