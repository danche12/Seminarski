using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO
{
    public class ZapamtiEvidencijuSO : SistemskaOperacijaBaza
    {
        private EvidencijaKursa evidencijaKursa { get; set; }
            public long Rez;

       public ZapamtiEvidencijuSO(EvidencijaKursa e)
            {
                evidencijaKursa = e;
            }

    protected override void Izvrsi()
    {
       /* if (evidencijaKursa.Stavke == null || evidencijaKursa.Stavke.Count == 0)
        {
            throw new InvalidOperationException("Evidencija mora imati bar jednu stavku.");
        }*/
        long id = repozitorijum.Dodaj(evidencijaKursa);   // INSERT Racun, vrati novi IdRacun
        Rez = id;
        evidencijaKursa.IdEvidencija = id;

        foreach (var stavka in evidencijaKursa.Stavke)
        {
            stavka.EvidencijaKursa = evidencijaKursa;
            repozitorijum.Dodaj(stavka);
        }
    }
}
}

