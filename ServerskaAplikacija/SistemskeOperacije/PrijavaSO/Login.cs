using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PrijavaSO
{
    public class Login : SistemskaOperacijaBaza
    {
        public Instruktor Rezultat { get; set; }

        private Instruktor instruktor;
        public Login(Instruktor i)
        {
            this.instruktor = i;
        }


        protected override void Izvrsi()
        {
            instruktor.Uslov = $"i.KorisnickoIme = '{instruktor.KorisnickoIme}' and i.Sifra = '{instruktor.Sifra}'";
            Rezultat = (Instruktor)repozitorijum.VratiJednog(instruktor);
        }
    }
}

