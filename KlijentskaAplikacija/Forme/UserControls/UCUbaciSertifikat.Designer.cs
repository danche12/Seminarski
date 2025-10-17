using System.Windows.Forms;

namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCUbaciSertifikat
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
            txtNaziv = new TextBox();
            txtInstitucija = new TextBox();
            btnZapamti = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(165, 76);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "UBACI SERTIFIKAT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 137);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Naziv";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 174);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Institucija";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(176, 134);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(190, 23);
            txtNaziv.TabIndex = 3;
            // 
            // txtInstitucija
            // 
            txtInstitucija.Location = new Point(178, 171);
            txtInstitucija.Name = "txtInstitucija";
            txtInstitucija.Size = new Size(188, 23);
            txtInstitucija.TabIndex = 4;
            // 
            // btnZapamti
            // 
            btnZapamti.BackColor = Color.RosyBrown;
            btnZapamti.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZapamti.ForeColor = SystemColors.ButtonHighlight;
            btnZapamti.Location = new Point(113, 224);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(253, 37);
            btnZapamti.TabIndex = 5;
            btnZapamti.Text = "DODAJ SERTIFIKAT";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // UCUbaciSertifikat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(btnZapamti);
            Controls.Add(txtInstitucija);
            Controls.Add(txtNaziv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCUbaciSertifikat";
            Size = new Size(548, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNaziv;
        private TextBox txtInstitucija;
        private Button btnZapamti;

        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }

        public TextBox TxtNaziv { get => txtNaziv; set => txtNaziv = value; }
        public TextBox TxtInstitucija { get => txtInstitucija; set => txtInstitucija = value; }

        public Button BtnZapamti { get => btnZapamti; set => btnZapamti = value; }
        
    }
}
