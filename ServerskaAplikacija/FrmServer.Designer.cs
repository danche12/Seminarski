namespace ServerskaAplikacija
{
    partial class FrmServer
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
            btnStart = new Button();
            lblStatus = new Label();
            btnStop = new Button();
            btnTestNedeljniMejlovi = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(128, 128);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(105, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Pokreni server!";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(128, 74);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status:";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(287, 128);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(105, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Zaustavi server!";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnTestNedeljniMejlovi
            // 
            btnTestNedeljniMejlovi.Location = new Point(128, 170);
            btnTestNedeljniMejlovi.Name = "btnTestNedeljniMejlovi";
            btnTestNedeljniMejlovi.Size = new Size(180, 23);
            btnTestNedeljniMejlovi.TabIndex = 3;
            btnTestNedeljniMejlovi.Text = "Test Nedeljni Mejlovi";
            btnTestNedeljniMejlovi.UseVisualStyleBackColor = true;
            btnTestNedeljniMejlovi.Click += btnTestNedeljniMejlovi_Click;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnTestNedeljniMejlovi);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Name = "FrmServer";
            Text = "FrmServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblStatus;
        private Button btnStop;
        private Button btnTestNedeljniMejlovi;
    }
}