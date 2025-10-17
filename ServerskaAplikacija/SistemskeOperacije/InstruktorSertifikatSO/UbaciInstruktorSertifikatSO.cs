using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.InstruktorSertifikatSO
{
    public class UbaciInstruktorSertifikatSO : SistemskaOperacijaBaza
    {
        private InstruktorSertifikat sertifikat { get; set; }

        public UbaciInstruktorSertifikatSO(InstruktorSertifikat ins)
        {
            sertifikat = ins;
        }
        protected override void Izvrsi()
        {
            repozitorijum.DodajBezId(sertifikat);
        }
    }
    
}
