using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.InstruktorSertifikatSO
{
    public class VratiInstruktorSertifikatSO : SistemskaOperacijaBaza
    {
        public List<InstruktorSertifikat> Rezultat { get; set; }


        protected override void Izvrsi()
        {

            Rezultat = repozitorijum.VratiSve(new InstruktorSertifikat()).Cast<InstruktorSertifikat>().ToList<InstruktorSertifikat>();
        }
    }
    
}
