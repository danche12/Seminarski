namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCKreiranjeCasa
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
            txtTema = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            labelModul = new Label();
            cmbModul = new ComboBox();
            btnZapamti = new Button();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label3 = new Label();
            txtCena = new TextBox();
            SuspendLayout();
            // 
            // txtTema
            // 
            txtTema.Location = new Point(297, 154);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(209, 23);
            txtTema.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 157);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 31;
            label2.Text = "Tema časa : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 57);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 30;
            label1.Text = "KREIRANJE ČASA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 302);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 42;
            label4.Text = "Cena kursa (RSD) :";
            // 
            // labelModul
            // 
            labelModul.AutoSize = true;
            labelModul.Location = new Point(194, 117);
            labelModul.Name = "labelModul";
            labelModul.Size = new Size(48, 15);
            labelModul.TabIndex = 44;
            labelModul.Text = "Modul :";
            // 
            // cmbModul
            // 
            cmbModul.BackColor = SystemColors.ButtonHighlight;
            cmbModul.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModul.Location = new Point(297, 114);
            cmbModul.Name = "cmbModul";
            cmbModul.Size = new Size(209, 23);
            cmbModul.TabIndex = 45;
            // 
            // btnZapamti
            // 
            btnZapamti.BackColor = Color.RosyBrown;
            btnZapamti.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZapamti.ForeColor = SystemColors.ButtonHighlight;
            btnZapamti.Location = new Point(194, 342);
            btnZapamti.Margin = new Padding(3, 2, 3, 2);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(312, 42);
            btnZapamti.TabIndex = 41;
            btnZapamti.Text = "ZAPAMTI ČAS";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(321, 261);
            radioButton3.Margin = new Padding(3, 2, 3, 2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(61, 19);
            radioButton3.TabIndex = 40;
            radioButton3.TabStop = true;
            radioButton3.Text = "90 min";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(323, 227);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 19);
            radioButton2.TabIndex = 39;
            radioButton2.TabStop = true;
            radioButton2.Text = "60 min";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(323, 195);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(61, 19);
            radioButton1.TabIndex = 38;
            radioButton1.TabStop = true;
            radioButton1.Text = "45 min";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 195);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 37;
            label3.Text = "Trajanje časa :";
            // 
            // txtCena
            // 
            txtCena.Location = new Point(297, 299);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(209, 23);
            txtCena.TabIndex = 43;
            // 
            // UCKreiranjeCasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(txtCena);
            Controls.Add(cmbModul);
            Controls.Add(labelModul);
            Controls.Add(label4);
            Controls.Add(btnZapamti);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label3);
            Controls.Add(txtTema);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCKreiranjeCasa";
            Size = new Size(746, 531);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTema;
        private Label label2;
        private Label label1;
        private Label label4;
        private Button btnZapamti;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label3;
        private TextBox txtCena;
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label LabelModul { get => labelModul; set => labelModul = value; }
        public TextBox TxtTemaCasa { get => txtTema; set => txtTema = value; }
        public RadioButton RadioButton1 { get => radioButton1; set => radioButton1 = value; }
        public RadioButton RadioButton2 { get => radioButton2; set => radioButton2 = value; }
        public RadioButton RadioButton3 { get => radioButton3; set => radioButton3 = value; }
        public Button BtnZapamti { get => btnZapamti; set => btnZapamti = value; }
        public TextBox TxtCena { get => txtCena; set => txtCena = value; }
        public ComboBox CmbModul { get => cmbModul; set => cmbModul = value; }

        private Label labelModul;
        private ComboBox cmbModul;
    }
}
