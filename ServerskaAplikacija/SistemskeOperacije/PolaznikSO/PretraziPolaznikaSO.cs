using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PolaznikSO
{
    public class PretraziPolaznikaSO : SistemskaOperacijaBaza
    {
        public List<Polaznik> Rezultat { get; set; }
        public Polaznik polaznik { get; set; }

        public PretraziPolaznikaSO(string[] uslov)
        {
            polaznik = new Polaznik();
            polaznik.Ime = uslov[0];
            polaznik.Prezime = uslov[1];
        }
        protected override void Izvrsi()
        {
            polaznik.Uslov = $"Ime='{polaznik.Ime}' AND Prezime='{polaznik.Prezime}'";

            Rezultat = repozitorijum.VratiPoUslovu(polaznik).Cast<Polaznik>().ToList();

        }
    }
}
