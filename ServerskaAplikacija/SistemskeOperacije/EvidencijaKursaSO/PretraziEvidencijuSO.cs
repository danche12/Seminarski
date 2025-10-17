using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO
{
    public class PretraziEvidencijuSO : SistemskaOperacijaBaza
    {
        public List<Common.Domen.EvidencijaKursa> Rezultat { get; set; }

        Common.Domen.EvidencijaKursa evidencijaKursa { get; set; }
        public PretraziEvidencijuSO(Common.Domen.EvidencijaKursa e)
        {
            evidencijaKursa = e;

        }

        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiPoUslovu(evidencijaKursa).Cast<Common.Domen.EvidencijaKursa>().ToList<Common.Domen.EvidencijaKursa>();
        }
    }
  
}
