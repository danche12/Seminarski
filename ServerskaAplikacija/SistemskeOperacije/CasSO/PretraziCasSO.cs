using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.CasSO
{
    internal class PretraziCasSO : SistemskaOperacijaBaza
    {
        public List<Cas> Rezultat { get; set; }
        public Cas cas { get; set; }

        public PretraziCasSO(Cas c)
        {
            cas = new Cas()
            {
                TemaCasa = c.TemaCasa
            };


        }
        protected override void Izvrsi()
        {
            cas.Uslov = $"TemaCasa='{cas.TemaCasa}'";

            Rezultat = repozitorijum.VratiPoUslovu(cas).Cast<Cas>().ToList();

        }

    }
  
}
