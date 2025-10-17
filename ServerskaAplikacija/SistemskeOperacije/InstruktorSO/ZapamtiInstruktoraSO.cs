using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.InstruktorSO
{
    internal class ZapamtiInstruktoraSO : SistemskaOperacijaBaza
    {
        public Instruktor Instruktor { get; set; }
        public ZapamtiInstruktoraSO(Instruktor i)
        {
            Instruktor = i;
        }
        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(Instruktor);
        }
    }
}

