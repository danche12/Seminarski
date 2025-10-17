using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija
{
    public class Server
    {
        Socket soket;
        bool kraj = false;

        private List<ClientHandler> prijavljeniKorisnici = new List<ClientHandler>();

        public Server()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Osluskuj()
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                soket.Bind(ipEndPoint);
                soket.Listen(5);

                MessageBox.Show("Osluskujem");

                while (!kraj)
                {
                    Debug.WriteLine("Cekam klijenta da se poveze");
                    Socket klijent = soket.Accept();
                    Debug.WriteLine("Klijent se uspesno povezao");
                    ClientHandler ch = new ClientHandler(klijent, prijavljeniKorisnici);
                    prijavljeniKorisnici.Add(ch);
                    Thread nitObrada = new Thread(ch.HandleRequest);
                    nitObrada.IsBackground = true;
                    nitObrada.Start();
                    nitObrada.IsBackground = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }

        }
        public void StopServer()
        {
            try
            {
                kraj = true;
                foreach (ClientHandler korisnik in prijavljeniKorisnici)
                {
                    korisnik.Stop();
                }
                try { soket?.Shutdown(SocketShutdown.Both); } catch { }
                try { soket?.Close(); } catch { }
            }
            catch (SocketException ex)
            {

                Debug.WriteLine(">>> Doslo je do greske na serverskoj strani prilikom zatvaranja soketa");
            }

        }

    }
}

