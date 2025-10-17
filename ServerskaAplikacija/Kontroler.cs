using Common.Domen;
using ServerskaAplikacija.SistemskeOperacije.InstruktorSO;
using ServerskaAplikacija.SistemskeOperacije.PolaznikSO;
using ServerskaAplikacija.SistemskeOperacije.PrebivalisteSO;
using ServerskaAplikacija.SistemskeOperacije.PrijavaSO;
using ServerskaAplikacija.SistemskeOperacije.CasSO;
using System;
using System.Collections.Generic;
using ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO;
using ServerskaAplikacija.SistemskeOperacije.SertifikatSO;
using ServerskaAplikacija.SistemskeOperacije.InstruktorSertifikatSO;

namespace ServerskaAplikacija
{
    public class Kontroler
    {

        private static Kontroler instance;

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }
        private Kontroler() { }
        public Instruktor Prijava(Instruktor i)
        {
            Login operacija = new Login(i);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public void ZapamtiPolaznika(Polaznik p)
        {
            ZapamtiPolaznikaSO operacija = new ZapamtiPolaznikaSO(p);
            operacija.ExecuteTemplate();
        }

        public List<Polaznik> PretraziPolaznika(string[] imeiprezime)
        {
            PretraziPolaznikaSO operacija = new PretraziPolaznikaSO(imeiprezime);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public int ObrisiPolaznika(Polaznik p)
        {
            ObrisiPolaznikaSO operacija = new ObrisiPolaznikaSO(p);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }


        public List<Prebivaliste> VratiPrebivalista()
        {
            VratiPrebivalistaSO operacija = new VratiPrebivalistaSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public void ZapamtiCas(Cas cas)
        {
            ZapamtiCasSO operacija = new ZapamtiCasSO(cas);
            operacija.ExecuteTemplate();
        }

        public void ZapamtiInstruktora(Instruktor instruktor)
        {
            ZapamtiInstruktoraSO operacija = new ZapamtiInstruktoraSO(instruktor);
            operacija.ExecuteTemplate();
        }

        public List<Polaznik> VratiPolaznike()
        {
            VratiPolaznikeSO operacija = new VratiPolaznikeSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public List<Cas> VratiCasove()
        {
            VratiCasoveSO operacija = new VratiCasoveSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public List<Instruktor> VratiInstruktore()
        {
            VratiInstruktoreSO operacija = new VratiInstruktoreSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public object PretraziCas(Cas cas)
        {
            PretraziCasSO operacija = new PretraziCasSO(cas);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public void AzurirajPolaznika(Polaznik pol)
        {
            AzurirajPolaznikaSO operacija = new AzurirajPolaznikaSO(pol);
            operacija.ExecuteTemplate();

        }

        public object PretraziInstruktora(Instruktor ins)
        {
            PretraziInstruktoraSO operacija = new PretraziInstruktoraSO(ins);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;

        }

        public long ZapamtiEvidenciju(EvidencijaKursa evidencija)
        {
            ZapamtiEvidencijuSO operacija = new ZapamtiEvidencijuSO(evidencija);
            operacija.ExecuteTemplate();
            return operacija.Rez;
        }

        public List<EvidencijaKursa> vratiEvidencije()
        {
            VratiEvidencijeSO operacija = new VratiEvidencijeSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;

        }

        public List<EvidencijaKursa> PretraziEvidenciju(EvidencijaKursa evidencija)
        {
            PretraziEvidencijuSO operacija = new PretraziEvidencijuSO(evidencija);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
            
        }
        public long AzurirajEvidencijuKursa(EvidencijaKursa evidencija)
        {
            AzurirajEvidencijuSO operacija = new AzurirajEvidencijuSO(evidencija);
            operacija.ExecuteTemplate();
            return operacija.Rez;
        }
        public EvidencijaKursa ucitajUgovor(EvidencijaKursa evidencija)
        {
            UcitajEvidencijuSO operacija = new UcitajEvidencijuSO(evidencija);
            operacija.ExecuteTemplate();
            return operacija.Rezultat;

        }
        public void UbaciInstruktorSertifikat(InstruktorSertifikat ins)
        {
            UbaciInstruktorSertifikatSO operacija = new UbaciInstruktorSertifikatSO(ins);
            operacija.ExecuteTemplate();
        }

        public List<Sertifikat> VratiSertifikate()
        {
            VratiSertifikatSO operacija = new VratiSertifikatSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }

        public List<InstruktorSertifikat> VratiInstruktorSertifikate()
        {
            VratiInstruktorSertifikatSO operacija = new VratiInstruktorSertifikatSO();
            operacija.ExecuteTemplate();
            return operacija.Rezultat;
        }
        public void UbaciSertifikat(Sertifikat s)
        {
            UbaciSertifikatSO operacija = new UbaciSertifikatSO(s);
            operacija.ExecuteTemplate();
        }

    }
}
