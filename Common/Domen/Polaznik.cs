using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Domen
{
    public class Polaznik : IEntitet
    {
        public long IdPolaznik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona{ get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja  { get; set; }
        public Prebivaliste Prebivaliste { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Polaznik";

   

        [Browsable(false)]
        public string UbaciVrednosti => $"'{Ime}','{Prezime}','{BrojTelefona}','{Email}','{DatumRodjenja:yyyy-MM-dd}',{Prebivaliste?.IdPrebivaliste}";

        [Browsable(false)]
        public string IdName => "IdPolaznik";

        [Browsable(false)]
        public string Alias => "p";

        [Browsable(false)]
        public string Select => "p.IdPolaznik, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.DatumRodjenja, p.Prebivaliste";

        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string WhereUslov =>$"{Uslov}";

        [Browsable(false)]
        public string UpdateVrednosti => $"Ime='{Ime}',Prezime='{Prezime}',BrojTelefona='{BrojTelefona}',Email='{Email}',DatumRodjenja='{DatumRodjenja:yyyy-MM-dd}',Prebivaliste={Prebivaliste?.IdPrebivaliste}";

        [Browsable(false)]
        public long IdPrebivaliste { get; set; }

        [Browsable(false)]
        public string PrebivalisteNaziv => Prebivaliste?.NazivMesta;


        [Browsable(false)]
        public long PrebivalistePostanskiBroj => Prebivaliste?.PostanskiBroj ?? 0;

        [Browsable(false)]

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public string ImePrezime => $"{Ime} {Prezime}";
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Polaznik
            {
                IdPolaznik = (long)reader[0],
                Ime= (string)reader[1],
                Prezime= (string)reader[2],
                BrojTelefona = (string)reader[3],
                Email = (string)reader[4],
                DatumRodjenja = (DateTime)reader[5],
                Prebivaliste= new Prebivaliste
                {
                    IdPrebivaliste = (long)reader[6]
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti=new List<IEntitet>();
            while (reader.Read()) {

                entiteti.Add(new Polaznik
                {
                    IdPolaznik = (long)reader[0],
                    Ime = (string)reader[1],
                    Prezime = (string)reader[2],
                    BrojTelefona = (string)reader[3],
                    Email = (string)reader[4],
                    DatumRodjenja = (DateTime)reader[5],
                    Prebivaliste = new Prebivaliste
                    {
                        IdPrebivaliste= (long)reader[6]
                    }
                });
            }
            return entiteti;
        }
    }
}
