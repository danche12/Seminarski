using KlijentskaAplikacija;
using System;

namespace KlijentskaAplikacija.Kontroleri
{
    public class KontrolerGlavneForme
    {
        private bool zatvaranjeZbogPrekida = false;   // <- NOVO
        private System.Windows.Forms.Timer _pingTimer;
        public GlavnaForma GlavnaForma { get; set; }

        public GlavnaForma NapraviGlavnuFormu()
        {
            GlavnaForma = new GlavnaForma();
            GlavnaForma.Dock = DockStyle.Fill;
            GlavnaForma.FormBorderStyle = FormBorderStyle.Sizable;
            GlavnaForma.StartPosition = FormStartPosition.CenterScreen;

            GlavnaForma.FormClosing += GlavnaForma_FormClosing;


            // <- SUBSCRIBE
            Komunikacija.Instance.Disconnected -= OnDisconnectedMain;
            Komunikacija.Instance.Disconnected += OnDisconnectedMain;
            GlavnaForma.FormClosed += (s, e) =>
                Komunikacija.Instance.Disconnected -= OnDisconnectedMain;

            //PAZI
            GlavnaForma.KreirajPolaznikaToolStripMenuItem.Click += KreiranjePolaznikaToolStripMenuItem_Click;
            GlavnaForma.KreirajCasToolStripMenuItem.Click += KreiranjeCasaToolStripMenuItem_Click;
            GlavnaForma.KreiranjeInstruktoraToolStripMenuItem.Click += KreiranjeNastavnikaStripMenuItem_Click;
            GlavnaForma.KreirajEvidencijuKursaToolStripMenuItem.Click += KreiranjeEvidencijeKursaStripMenuItem_Click;
            GlavnaForma.PretraziPolaznikaToolStripMenuItem.Click += PretrazivanjePolaznikaStripMenuItem_Click;
            GlavnaForma.PretrazivanjeCasaToolStripMenuItem.Click += PretrazivanjeCasaToolStripMenuItem_Click;
            GlavnaForma.PretraziInstruktoraToolStripMenuItem.Click += PretrazivanjeNastavnikaToolStripMenuItem_Click;
            GlavnaForma.PretraziEvidencijuKursaToolStripMenuItem.Click += PretrazivanjeEvidencijuKursaToolStripMenuItem_Click;
            GlavnaForma.UbaciSertifikatToolStripMenuItem.Click += UbaciSertifikatToolStripMenuItem_Click;
            GlavnaForma.UbaciSertifikatZaInstruktoraToolStripMenuItem.Click += UbaciSertifikatZaInstruktoraToolStripMenuItem_Click;
            _pingTimer = new System.Windows.Forms.Timer { Interval = 1000 }; // 1s
            _pingTimer.Tick += (s, e) =>
            {
                // pinguj samo ako je konekcija uspostavljena
                if (Komunikacija.Instance.jns != null && !Komunikacija.Instance.TryPing())
                {
                    _pingTimer.Stop();
                    MessageBox.Show(GlavnaForma, "Server je prestao sa radom. Aplikacija će se zatvoriti.",
                                    "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit(); // zatvara i glavnu i login
                }
            };
            _pingTimer.Start();

            GlavnaForma.FormClosed += (s, e) => _pingTimer.Stop();

            return GlavnaForma;
        }


        private void OnDisconnectedMain()
        {
            if (GlavnaForma?.IsHandleCreated == true)
                GlavnaForma.BeginInvoke(new Action(() =>
                {
                    zatvaranjeZbogPrekida = true;
                    MessageBox.Show(GlavnaForma, "Veza sa serverom je prekinuta. Aplikacija će se zatvoriti.",
                                    "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GlavnaForma.Close();
                    Application.Exit();
                }));
        }

        private void GlavnaForma_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UbaciSertifikatToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCUbaciSertifikat();
        }
        private void UbaciSertifikatZaInstruktoraToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCUbaciSertifikatZaInstruktora();
        }

        private void PretrazivanjeEvidencijuKursaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCPretrazivanjeEvidencijeKursa();
        }

        private void KreiranjeEvidencijeKursaStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCKreiranjeEvidencijeKursa();
        }

        private void PretrazivanjeNastavnikaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCPretrazivanjeInstruktora();
        }

        private void PretrazivanjeCasaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.otvoriUCPretrazivanjeCasova();
        }

        private void PretrazivanjePolaznikaStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriUCPretrazivanjePolaznika();
        }

        private void KreiranjeNastavnikaStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriUCKreiranjeInstruktora();
        }

        private void KreiranjeCasaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriUCKreiranjeCasa();
        }

        private void KreiranjePolaznikaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriUCKreiranjePolaznika();
        }

    }
}
