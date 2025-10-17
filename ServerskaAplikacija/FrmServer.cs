using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using ServerskaAplikacija.SistemskeOperacije;

namespace ServerskaAplikacija
{
    public partial class FrmServer : Form
    {
        private Server server;
        private System.Windows.Forms.Timer timerNedeljniMejlovi;
        
        public FrmServer()
        {
            InitializeComponent();
            server = new Server();
            btnStop.Enabled = false;
            
            // Inicijalizuj Timer za nedeljne mejlove
            InicijalizujTimerNedeljniMejlovi();
        }
        
        private void InicijalizujTimerNedeljniMejlovi()
        {
            timerNedeljniMejlovi = new System.Windows.Forms.Timer();
            timerNedeljniMejlovi.Interval = 60000; // Proverava svakih 60 sekundi
            timerNedeljniMejlovi.Tick += TimerNedeljniMejlovi_Tick;
            timerNedeljniMejlovi.Start();
        }
        
        private void TimerNedeljniMejlovi_Tick(object sender, EventArgs e)
        {
            DateTime sada = DateTime.Now;
            
            // Proveri da li je nedelja i 15:00
            if (sada.DayOfWeek == DayOfWeek.Sunday && sada.Hour == 15 && sada.Minute == 0)
            {
                // Pokreni slanje nedeljnih mejlova u pozadini
                Thread nitZaMejl = new Thread(PosaljiNedeljneMejlove);
                nitZaMejl.Start();
            }
        }
        
        private void PosaljiNedeljneMejlove()
        {
            try
            {
                // Pozovi sistemsku operaciju za slanje nedeljnih mejlova
                PosaljiNedeljneMejloveSO operacija = new PosaljiNedeljneMejloveSO();
                operacija.ExecuteTemplate();
            }
            catch (Exception ex)
            {
                // Log greške (možeš dodati logging sistem)
                System.Diagnostics.Debug.WriteLine($"Greška pri slanju nedeljnih mejlova: {ex.Message}");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            try
            {
                lblStatus.Text = "Server je pokrenut";

                Thread nit = new Thread(server.Osluskuj);
                nit.Start();

                btnStop.Enabled = true;
                btnStart.Enabled = false;

            }
            catch (SocketException ex)
            {

                MessageBox.Show("Greska prilikom pokretanja servera");
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {

                lblStatus.Text = "Server je zaustavljen";

                btnStop.Enabled = false;
                btnStart.Enabled = true;
                server?.StopServer();
            }
            catch (SocketException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestNedeljniMejlovi_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Pokretanje testa nedeljnih mejlova...");
                
                // Pokreni slanje nedeljnih mejlova u pozadini
                Thread nitZaMejl = new Thread(PosaljiNedeljneMejlove);
                nitZaMejl.Start();
                
                MessageBox.Show("Test nedeljnih mejlova je pokrenut u pozadini. Proverite email adrese.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri pokretanju testa: {ex.Message}");
            }
        }
    }
}
