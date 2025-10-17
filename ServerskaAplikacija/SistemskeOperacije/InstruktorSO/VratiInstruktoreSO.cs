using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.InstruktorSO
{
    internal class VratiInstruktoreSO : SistemskaOperacijaBaza
    {
        public List<Instruktor> Rezultat { get; set; }
        protected override void Izvrsi()
        {

            Rezultat = repozitorijum.VratiSve(new Instruktor()).Cast<Instruktor>().ToList();
        }
    
    }
}
