namespace KlijentskaAplikacija.Forme.UserControls
{
    partial class UCPretrazivanjeCasa
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
            txtTema = new TextBox();
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
            btnPretrazi.Location = new Point(512, 70);
            btnPretrazi.Margin = new Padding(3, 2, 3, 2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(144, 30);
            btnPretrazi.TabIndex = 9;
            btnPretrazi.Text = "PRETRAŽI";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 125);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(613, 242);
            dataGridView1.TabIndex = 8;
            // 
            // txtTema
            // 
            txtTema.Location = new Point(87, 75);
            txtTema.Margin = new Padding(3, 2, 3, 2);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(413, 23);
            txtTema.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 78);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 6;
            label2.Text = "Tema:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(264, 31);
            label1.Name = "label1";
            label1.Size = new Size(183, 23);
            label1.TabIndex = 5;
            label1.Text = "PRETRAŽIVANJE ČASA";
            // 
            // UCPretrazivanjeCasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(btnPretrazi);
            Controls.Add(dataGridView1);
            Controls.Add(txtTema);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCPretrazivanjeCasa";
            Size = new Size(717, 415);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPretrazi;
        private DataGridView dataGridView1;
        private TextBox txtTema;
        private Label label2;
        private Label label1;
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtTema { get => txtTema; set => txtTema = value; }
        public DataGridView DataGridView1 { get => dataGridView1; set => dataGridView1 = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
    }
}
