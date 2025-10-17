using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.SertifikatSO
{
    public class UbaciSertifikatSO : SistemskaOperacijaBaza
    {
        public Sertifikat Sertifikat { get; set; }
        public UbaciSertifikatSO(Sertifikat s)
        {
            Sertifikat = s;
        }
        protected override void Izvrsi()
        {
            repozitorijum.DodajBezId(Sertifikat);
        }
    }
   
}
