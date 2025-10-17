using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Domen
{
    public class Instruktor:IEntitet
    {
        public long IdInstruktor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string Uslov { get; set; }

        public string ImeTabele => "Instruktor";

        public string UbaciVrednosti => $"'{Ime}','{Prezime}','{BrojTelefona}','{Email}','{KorisnickoIme}', '{Sifra}'";

        public string IdName => "IdInstruktor";

        public string JoinUslov => "";

        public string Alias => "i";

        public string Select => "*";

        public string WhereUslov => $"{Uslov}";

        public string UpdateVrednosti => $"Ime='{Ime}',Prezime='{Prezime}',BrojTelefona='{BrojTelefona}',Email='{Email}',KorisnickoIme='{KorisnickoIme}',Sifra= '{Sifra}'";

        public string ImePrezime => $"{Ime} {Prezime}";

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {

            return new Instruktor
            {
                IdInstruktor = (long)reader[0],
                Ime = (string)reader[1],
                Prezime = (string)reader[2],
                BrojTelefona = (string)reader[3],
                Email = (string)reader[4],
                KorisnickoIme = (string)reader[5],
                Sifra = (string)reader[6],
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new Instruktor
                {

                    IdInstruktor = (long)reader[0],
                    Ime = (string)reader[1],
                    Prezime = (string)reader[2],
                    BrojTelefona = (string)reader[3],
                    Email = (string)reader[4],
                    KorisnickoIme = (string)reader[5],
                    Sifra = (string)reader[6],
                });
            }
            return entiteti;
        }
    }
}
