using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.CasSO
{
    internal class ZapamtiCasSO : SistemskaOperacijaBaza
    {
        private Cas cas { get; set; }

        public ZapamtiCasSO(Cas c)
        {
            cas = c;
        }
        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(cas);
        }
    }
}


