using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PolaznikSO
{
    internal class ZapamtiPolaznikaSO : SistemskaOperacijaBaza
    {
        private Polaznik polaznik { get; set; }
        public ZapamtiPolaznikaSO(Polaznik p)
        {
            polaznik = p;
        }
        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(polaznik);
        }
    }
}
