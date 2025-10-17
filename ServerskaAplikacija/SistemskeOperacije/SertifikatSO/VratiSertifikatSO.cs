using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.SertifikatSO
{
    public class VratiSertifikatSO : SistemskaOperacijaBaza
    {
        public List<Sertifikat> Rezultat { get; set; }


        protected override void Izvrsi()
        {

            Rezultat = repozitorijum.VratiSve(new Sertifikat()).Cast<Sertifikat>().ToList<Sertifikat>();
        }
    }
}
