using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domen
{
    public class EvidencijaKursa:IEntitet
    {
        public long IdEvidencija { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public double UkupnaCena { get; set; }
        public Polaznik Polaznik { get; set; }
        public Instruktor Instruktor { get; set; }
        public List<StavkaEvidencijeKursa> Stavke { get; set; }
        public List<StavkaEvidencijeKursa> StavkeZaBrisanje { get; set; }
        public string Uslov { get; set; }
        public string ImeTabele => "EvidencijaKursa";

        public string UbaciVrednosti => $"'{DatumPocetka:yyyy-MM-dd}','{DatumZavrsetka:yyyy-MM-dd}',{UkupnaCena},{Polaznik?.IdPolaznik},{Instruktor?.IdInstruktor}";

        public string IdName => "IdEvidencija";

        public string JoinUslov => "JOIN Polaznik po ON (po.IdPolaznik = ek.Polaznik) " +
                                   "JOIN Instruktor i ON (i.IdInstruktor = ek.Instruktor)";

        public string Alias => "ek";

        public string Select => "ek.IdEvidencija, ek.DatumPocetka, ek.DatumZavrsetka, ek.UkupnaCena, " +
                                 "i.IdInstruktor, i.Ime, i.Prezime, " +
                                 "po.IdPolaznik, po.Ime, po.Prezime";

        public string WhereUslov => $"{Uslov}";

        public string UpdateVrednosti => $"DatumPocetka='{DatumPocetka:yyyy-MM-dd}',DatumZavrsetka='{DatumZavrsetka:yyyy-MM-dd}',UkupnaCena={UkupnaCena},Polaznik={Polaznik?.IdPolaznik},Instruktor={Instruktor?.IdInstruktor}";

        public override string ToString()
        {
            return $"{IdEvidencija}";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new EvidencijaKursa
            {
                IdEvidencija = (long)reader[0],
                DatumPocetka = (DateTime)reader[1],
                DatumZavrsetka = (DateTime)reader[2],
                UkupnaCena = (double)reader[3],
                Instruktor = new Instruktor
                {
                    IdInstruktor = (long)reader[4],
                    Ime = (string)reader[5],
                    Prezime = (string)reader[6]
                },
                Polaznik = new Polaznik
                {
                    IdPolaznik = (long)reader[7],
                    Ime = (string)reader[8],
                    Prezime = (string)reader[9]
                }
            };

        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new EvidencijaKursa
                {
                    IdEvidencija = (long)reader[0],
                    DatumPocetka = (DateTime)reader[1],
                    DatumZavrsetka = (DateTime)reader[2],
                    UkupnaCena = (double)reader[3],
                    Instruktor = new Instruktor
                    {
                        IdInstruktor = (long)reader[4],
                        Ime = (string)reader[5],
                        Prezime = (string)reader[6]
                    },
                    Polaznik = new Polaznik
                    {
                        IdPolaznik = (long)reader[7],
                        Ime = (string)reader[8],
                        Prezime = (string)reader[9]
                    }
                });
            }

            return entiteti;
        }
    }
}
