using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.CasSO
{
    public class VratiCasoveSO : SistemskaOperacijaBaza
    {
        public List<Cas> Rezultat { get; set; }

        protected override void Izvrsi()
        {

            Rezultat = repozitorijum.VratiSve(new Cas()).Cast<Cas>().ToList<Cas>();
        }
    }
}
