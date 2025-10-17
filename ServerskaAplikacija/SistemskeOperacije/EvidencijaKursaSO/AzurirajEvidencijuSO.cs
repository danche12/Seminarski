using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO
{
    internal class AzurirajEvidencijuSO : SistemskaOperacijaBaza
    {
        private EvidencijaKursa evidencija;
        public long Rez;

        public AzurirajEvidencijuSO(EvidencijaKursa ek)
        {
            this.evidencija = ek;
        }

        protected override void Izvrsi()
        {
            foreach (var stavkaBrisanje in evidencija.StavkeZaBrisanje)
            {
                if (stavkaBrisanje.EvidencijaKursa.IdEvidencija != 0)
                {
                    stavkaBrisanje.Uslov = $"EvidencijaKursa = {stavkaBrisanje.EvidencijaKursa.IdEvidencija} and Rb = {stavkaBrisanje.Rb}";
                    repozitorijum.Obrisi(stavkaBrisanje);
                }
            }

            if (evidencija.Stavke.Count == 0)
            {
                EvidencijaKursa evidencijaZaBrisanje = new EvidencijaKursa();
                evidencijaZaBrisanje.Uslov = $"IdEvidencija = {evidencija.IdEvidencija}";
                Rez = evidencija.IdEvidencija;
                repozitorijum.Obrisi(evidencijaZaBrisanje);
            }
            else
            {

                Rez = evidencija.IdEvidencija;
                double ukupanIznos = 0;
                foreach (var stavka in evidencija.Stavke)
                {
                    
                    if (stavka.EvidencijaKursa == null || stavka.EvidencijaKursa.IdEvidencija == 0)
                    {
                        stavka.EvidencijaKursa = evidencija;
                        ukupanIznos += stavka.Cena;
                        repozitorijum.Dodaj(stavka);
                    }
                    else
                    {
                        ukupanIznos += stavka.Cena;
                        stavka.Uslov = $"EvidencijaKursa = {stavka.EvidencijaKursa.IdEvidencija} and Rb = {stavka.Rb}";
                        repozitorijum.Promeni(stavka);
                    }

                }
                evidencija.UkupnaCena = ukupanIznos;
                evidencija.DatumPocetka = DateTime.Now;
                evidencija.DatumZavrsetka = DateTime.Now.AddMonths(3);
                evidencija.Uslov = $"IdEvidencija = {evidencija.IdEvidencija}";
                repozitorijum.Promeni(evidencija);
            }
        }
    }
}
