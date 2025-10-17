using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PolaznikSO
{
    public class ObrisiPolaznikaSO : SistemskaOperacijaBaza
    {
        private Polaznik polaznik;
        public int Rezultat { get; set; }
        public ObrisiPolaznikaSO(Polaznik p)
        {
            polaznik = p;
        }
        protected override void Izvrsi()
        {
            List<Common.Domen.EvidencijaKursa> evidencije = repozitorijum.VratiSve(new Common.Domen.EvidencijaKursa()).Cast<Common.Domen.EvidencijaKursa>().ToList();

            for (int i = 0; i < evidencije.Count; i++)
            {
                if (evidencije[i].Polaznik.IdPolaznik == ((Polaznik)polaznik).IdPolaznik)
                {
                    Rezultat = 0;
                    return;
                }
            }
            Rezultat = 1;
            polaznik.Uslov = $"idPolaznik = {polaznik.IdPolaznik}";
            repozitorijum.Obrisi(polaznik);
        }
    }
}
