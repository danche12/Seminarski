using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace KlijentskaAplikacija
{
    public class Komunikacija
    {
        private Socket socket;
        public JsonNetworkSerializer jns;

        private static Komunikacija instance;

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }
        private Komunikacija() { }

        //??????
        public event Action? Disconnected;

   
       
        public void PoveziSe()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            jns = new JsonNetworkSerializer(socket);
        }

        public bool TryPing()
        {
            if (jns == null) return false;
            try
            {
                var z = new Zahtev { Operacija = Operacija.Ping };
                jns.PosaljiPoruku(z);
                var _ = jns.PrimiPoruku<Odgovor>();
                return true;
            }
            catch (IOException) { return false; }
            catch (SocketException) { return false; }
            catch (ObjectDisposedException) { return false; }
        }

        public Odgovor PrijaviSe(Instruktor instruktor)
        {
            Zahtev zahtev = new Zahtev
            {
                Podatak = instruktor,
                Operacija = Operacija.Login
            };

            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        public Odgovor VratiPrebivalista()
        {
            Zahtev zahtev = new Zahtev
            {
                Podatak = new List<Prebivaliste>(),
                Operacija = Operacija.VratiPrebivalista
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;


        }

        public Odgovor ZapamtiPolaznika(Polaznik polaznik)
        {
            Zahtev zahtev = new Zahtev
            {
                Podatak = polaznik,
                Operacija = Operacija.ZapamtiPolaznika
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;

        }

        internal Odgovor ZapamtiInstruktora(object kuvar)
        {
            Zahtev zahtev = new Zahtev
            {
                Podatak = kuvar,
                Operacija = Operacija.ZapamtiInstruktora

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor ZapamtiCas(Cas cas)
        {
            Zahtev zahtev = new Zahtev
            {
                Podatak = cas,
                Operacija = Operacija.ZapamtiCas

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor VratiPolaznike()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiPolaznike,
                Podatak = new List<Polaznik>()

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();

            return odgovor;
        }

        internal Odgovor PretraziPolaznika(string[] imeiprezime)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PretraziPolaznika,
                Podatak = imeiprezime

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor AzurirajPolaznika(Polaznik novi)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.AzurirajPolaznika,
                Podatak = novi
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor ObrisiPolaznika(Polaznik polaznik)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ObrisiPolaznika,
                Podatak = polaznik

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor PretraziInstruktora(Instruktor instruktor)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PretraziInstruktora,
                Podatak = instruktor

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor VratiInstruktore()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiInstruktore,
                Podatak = new List<Instruktor>()

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor PretraziCas(Cas cas)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PretraziCas,
                Podatak = cas

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor VratiCasove()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiCasove,
                Podatak = new List<Cas>()

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();

            return odgovor;
        }
        internal void Logout()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.Logout,

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
        }

        internal Odgovor ZapamtiEvidencijuKursa(EvidencijaKursa evidencijaKursa)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ZapamtiEvidencijuKursa,
                Podatak = evidencijaKursa
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor UcitajUgovor(EvidencijaKursa evidencija)
        {
             Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajEvidencijuKursa,
                Podatak = evidencija

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor AzurirajEvidenciju(EvidencijaKursa evidencijaZaIzmenu)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.AzurirajEvidenciju,
                Podatak = evidencijaZaIzmenu

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor PretraziEvidencijeKursa(EvidencijaKursa evidencija)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.PretraziEvidencijuKursa,
                Podatak = evidencija

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor VratiEvidencijeKursa()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiEvidencijeKursa,
                Podatak = new List<EvidencijaKursa>()

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor UbaciSertifikatZaInstruktora(InstruktorSertifikat ins)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UbaciInstruktorSertifikat,
                Podatak = ins
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

        internal Odgovor VratiSertifikate()
        {

            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.VratiSertifikate,
                Podatak = new List<Sertifikat>()

            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }
        internal Odgovor UbaciSertifikat(Sertifikat s)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UbaciSertifikat,
                Podatak = s
            };
            jns.PosaljiPoruku(zahtev);
            Odgovor odgovor = jns.PrimiPoruku<Odgovor>();
            return odgovor;
        }

    }
}
