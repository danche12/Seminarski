using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO
{
    public class VratiEvidencijeSO : SistemskaOperacijaBaza
    {
        public List<Common.Domen.EvidencijaKursa> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Common.Domen.EvidencijaKursa()).Cast<Common.Domen.EvidencijaKursa>().ToList<Common.Domen.EvidencijaKursa>();

        }
    }
}
