using Common.Domen;
using Common.Transfer;
using KlijentskaAplikacija;

public class LoginKontroler
{
    private Login Forma { get; set; }
    private System.Windows.Forms.Timer _loginPingTimer;

    public Login NapraviLoginFormu()
    {
        Forma = new Login();
        Forma.StartPosition = FormStartPosition.CenterScreen;
        Forma.TxtPassword.PasswordChar = '*';

        Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;
        Komunikacija.Instance.Disconnected += OnDisconnectedLogin;

        Forma.FormClosed += (s, e) => Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;

        _loginPingTimer = new System.Windows.Forms.Timer { Interval = 10000 };
        _loginPingTimer.Tick += async (s, e) =>
        {
            if (Komunikacija.Instance.jns != null)
            {
                // Prebacujemo ping operaciju na background thread da ne blokira UI
                bool pingSuccess = await Task.Run(() => Komunikacija.Instance.TryPing());

                if (!pingSuccess)
                {
                    _loginPingTimer.Stop();
                    MessageBox.Show(Forma, "Server je prestao sa radom. Aplikacija se zatvara!", "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        };
        _loginPingTimer.Start();

        Forma.FormClosed += (s, e) =>
        {
            _loginPingTimer?.Stop();
            _loginPingTimer?.Dispose();
            Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;
        };

        Forma.BtnLogin.Click += BtnLogin_Click;
        return Forma;
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Forma.TxtUsername.Text) || string.IsNullOrEmpty(Forma.TxtPassword.Text))
        {
            MessageBox.Show("Niste uneli korisnicko ime ili lozinku!");
            return;
        }

        // Onemogućavamo dugme tokom login-a da se spreči duplo kliknuće
        Forma.BtnLogin.Enabled = false;

        try
        {
            string username = Forma.TxtUsername.Text;
            string password = Forma.TxtPassword.Text;

            Instruktor instruktor = new Instruktor
            {
                KorisnickoIme = username,
                Sifra = password
            };

            // Prebacujemo login operaciju na background thread
            Odgovor o = await Task.Run(() => Komunikacija.Instance.PrijaviSe(instruktor));

            try
            {
                if (!o.IsSuccessful)
                {
                    MessageBox.Show("Sistem ne moze da prijavi korisnika");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }

            if (o.Podatak == null)
            {
                MessageBox.Show("Korisnicko ime i sifra nisu ispravni!");
                MessageBox.Show("Ne moze da se otvori glavna forma i meni!");
                return;
            }

            MessageBox.Show("Korisnicko ime i sifra su ispravni!");

            _loginPingTimer?.Stop();
            _loginPingTimer?.Dispose();
            Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;

            Forma.Dispose();
            Koordinator.Instance.OtvoriGlavnuFormu();
        }
        finally
        {
            // Vraćamo dugme u enabled stanje ako se nešto pogrešno desi
            if (Forma != null && !Forma.IsDisposed)
            {
                Forma.BtnLogin.Enabled = true;
            }
        }
    }

    private void OnDisconnectedLogin()
    {
        _loginPingTimer?.Stop();

        //ako je forma jos ziva
        if (Forma != null && !Forma.IsDisposed)
        {
            Forma.BeginInvoke(new Action(() =>
            {
                MessageBox.Show(Forma, "Server je prestao sa radom. Aplikacija se zatvara!", "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }));
        }
        else
        {
            MessageBox.Show(Forma, "Server je prestao sa radom. Aplikacija se zatvara!", "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Exit();
        }
    }
}
