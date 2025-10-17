
using Common.Domen;
using KlijentskaAplikacija.Forme;
using KlijentskaAplikacija.Forme.UserControls;
using KlijentskaAplikacija.Kontroleri;
using System;

namespace KlijentskaAplikacija
{
    public class Koordinator
    {
        private static Koordinator instance;

        private LoginKontroler loginKontroler;
        private KontrolerGlavneForme kontrolerGlavneForme;
        private KontrolerUCKreirajPolaznika kontrolerUCKreirajPolaznika;
        private KontrolerUCKreirajCas kontrolerUCKreirajCas;
        private KontrolerUCKreirajInstruktora kontrolerUCKreirajInstruktora;
        private KontrolerUCPretraziPolaznika kontrolerUCPretraziPolaznika;
        private KontrolerUCPretraziCas kontrolerUCPretraziCas;
        private KontrolerUCPretraziInstruktora kontrolerUCPretraziInstruktora;
        private KontrolerUCUbaciSertifikatZaInstruktora kontrolerUCUbaciSertifikatZaInstruktora;
        private KontrolerFRMKreirajEvidencijuKursa kontrolerFRMKreirajEvidencijuKursa;
        private KontrolerFRMPretraziEvidencijuKursa kontrolerFRMPretraziEvidencijuKursa;
        private KontrolerUCUbaciSertifikat kontrolerUCUbaciSertifikat;

        public Instruktor Instruktor { get; set; }
        public Login LoginForma { get; set; }
       
    
        public GlavnaForma GlavnaForma { get; set; }

        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        }

        public Koordinator()
        {
            loginKontroler = new LoginKontroler();
            kontrolerGlavneForme = new KontrolerGlavneForme();
            kontrolerUCKreirajPolaznika = new KontrolerUCKreirajPolaznika();
            kontrolerUCKreirajCas = new KontrolerUCKreirajCas();
            kontrolerUCKreirajInstruktora = new KontrolerUCKreirajInstruktora();
            kontrolerFRMKreirajEvidencijuKursa = new KontrolerFRMKreirajEvidencijuKursa();
            kontrolerUCPretraziPolaznika = new KontrolerUCPretraziPolaznika();
            kontrolerUCPretraziCas = new KontrolerUCPretraziCas();
            kontrolerUCPretraziInstruktora = new KontrolerUCPretraziInstruktora();
            kontrolerFRMPretraziEvidencijuKursa = new KontrolerFRMPretraziEvidencijuKursa();
            kontrolerUCUbaciSertifikatZaInstruktora = new KontrolerUCUbaciSertifikatZaInstruktora();
            kontrolerUCUbaciSertifikat = new KontrolerUCUbaciSertifikat();
        }

        public void otvoriLoginFormu()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da se poveze na server");
                return;
            }

            LoginForma = loginKontroler.NapraviLoginFormu();
            LoginForma.ShowDialog();

        }

        public void OtvoriGlavnuFormu()
        {
            GlavnaForma = kontrolerGlavneForme.NapraviGlavnuFormu();
            GlavnaForma.ShowDialog();

        }

        public void OtvoriUCKreiranjePolaznika()
        {
            GlavnaForma.PostaviPanel(kontrolerUCKreirajPolaznika.NapraviUC());
        }

        internal void OtvoriUCKreiranjeCasa()
        {
            GlavnaForma.PostaviPanel(kontrolerUCKreirajCas.NapraviUC());
        }

        internal void OtvoriUCKreiranjeInstruktora()
        {
            GlavnaForma.PostaviPanel(kontrolerUCKreirajInstruktora.NapraviUC());
        }

        internal void OtvoriUCPretrazivanjePolaznika()
        {
            GlavnaForma.PostaviPanel(kontrolerUCPretraziPolaznika.NapraviUC());
        }

        internal void otvoriUCPretrazivanjeCasova()
        {
            GlavnaForma.PostaviPanel(kontrolerUCPretraziCas.NapraviUC());

        }

        internal void otvoriUCPretrazivanjeInstruktora()
        {
            GlavnaForma.PostaviPanel(kontrolerUCPretraziInstruktora.NapraviUC());
        }

        internal void otvoriUCKreiranjeEvidencijeKursa()
        {
            KreirajEvidencijuKursa frm = kontrolerFRMKreirajEvidencijuKursa.NapraviUC();
            frm.ShowDialog();
        }
        internal void otvoriUCPretrazivanjeEvidencijeKursa()
        {
            PretraziEvidencijuKursa frm = kontrolerFRMPretraziEvidencijuKursa.Napravi();
            frm.ShowDialog();
        }

        internal void otvoriUCUbaciSertifikatZaInstruktora()
        {
            GlavnaForma.PostaviPanel(kontrolerUCUbaciSertifikatZaInstruktora.NapraviUC());
        }
        internal void otvoriUCUbaciSertifikat()
        {
            GlavnaForma.PostaviPanel(kontrolerUCUbaciSertifikat.NapraviUC());
        }
    }
}
