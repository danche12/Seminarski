using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.EvidencijaKursaSO
{
    public class UcitajEvidencijuSO : SistemskaOperacijaBaza
    {
        public EvidencijaKursa Rezultat { get; set; }
        EvidencijaKursa evidencija;
        public UcitajEvidencijuSO(EvidencijaKursa evidencija)
        {
            this.evidencija = evidencija;
        }
        protected override void Izvrsi()
        {
            StavkaEvidencijeKursa s = new StavkaEvidencijeKursa()
            {
                EvidencijaKursa = evidencija
            };
            s.Uslov = $"ek.IdEvidencija = {evidencija.IdEvidencija}";
            List<StavkaEvidencijeKursa> stavke = repozitorijum.VratiPoUslovu(s).Cast<StavkaEvidencijeKursa>().ToList();
            evidencija.Stavke = stavke;
            Rezultat = evidencija;
        }

    }
}
