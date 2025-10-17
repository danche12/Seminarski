using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PolaznikSO
{
    public class VratiPolaznikeSO : SistemskaOperacijaBaza
    {
        public List<Polaznik> Rezultat { get; set; }

        protected override void Izvrsi()
        {

            Rezultat = repozitorijum.VratiSve(new Polaznik()).Cast<Polaznik>().ToList<Polaznik>();


        }
    }
}
