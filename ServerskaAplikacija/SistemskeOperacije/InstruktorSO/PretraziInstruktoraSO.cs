using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.InstruktorSO
{
    internal class PretraziInstruktoraSO : SistemskaOperacijaBaza
    {
        public List<Instruktor> Rezultat { get; set; }
        public Instruktor instruktor { get; set; }

        public PretraziInstruktoraSO(Instruktor i)
        {
            instruktor = new Instruktor()
            {
                Ime = i.Ime,
                Prezime = i.Prezime

            };
        }
        protected override void Izvrsi()
        {
            instruktor.Uslov = $"Ime='{instruktor.Ime}' AND Prezime='{instruktor.Prezime}'";

            Rezultat = repozitorijum.VratiPoUslovu(instruktor).Cast<Instruktor>().ToList();

        }
    }
}
