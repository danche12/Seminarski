using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.SistemskeOperacije.PolaznikSO
{
   
        internal class AzurirajPolaznikaSO : SistemskaOperacijaBaza
        {
            private Polaznik polaznik;

            public AzurirajPolaznikaSO(Polaznik p)
            {
                this.polaznik = p;
            }

            protected override void Izvrsi()
            {
                polaznik.Uslov = $"idPolaznik = {polaznik.IdPolaznik}";
                repozitorijum.Promeni(polaznik);
            }

        }
    }

