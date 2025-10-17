using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PrebivalisteSO
{
    internal class VratiPrebivalistaSO : SistemskaOperacijaBaza
    {
        public List<Prebivaliste> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Prebivaliste()).Cast<Prebivaliste>().ToList();
        }
    }
}

