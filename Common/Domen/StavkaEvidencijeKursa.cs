using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Domen
{
    public class StavkaEvidencijeKursa : IEntitet
    {
        public EvidencijaKursa EvidencijaKursa { get; set; }
        [Browsable(false)]
        public long Rb { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public double Cena { get; set; }
        public Cas Cas { get; set; }
        public string Modul => Cas?.Modul;
        public string TemaCasa => Cas?.TemaCasa;
        public string Uslov { get; set; }
        
        public string ImeTabele => "StavkaEvidencijeKursa";

        public string UbaciVrednosti => $"{EvidencijaKursa?.IdEvidencija},{Rb}," +
            $"'{DatumOdrzavanja:yyyy-MM-dd HH:mm:ss}',{Cena},{Cas.IdCas}";

        public string IdName => "Rb";

        public string JoinUslov => "Join EvidencijaKursa ek on (ek.IdEvidencija=se.EvidencijaKursa) Join Cas c on (c.IdCas=se.Cas)";

        public string Alias => "se";

        public string Select => "se.Rb, se.EvidencijaKursa, se.DatumOdrzavanja, se.Cena, se.Cas, c.TemaCasa, c.Modul";

        public string WhereUslov => $"{Uslov}";

        public string UpdateVrednosti => $"EvidencijaKursa={EvidencijaKursa?.IdEvidencija},Rb={Rb}," +
                   $"DatumOdrzavanja='{DatumOdrzavanja:yyyy-MM-dd HH:mm:ss}',Cena={Cena},Cas={Cas.IdCas}";
        public override string ToString()
        {
            return $"{Rb}. [{Cas?.Modul}] {Cas?.TemaCasa} - {DatumOdrzavanja:dd.MM.yyyy HH:mm} - {Cena} RSD";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new StavkaEvidencijeKursa
            {
                Rb = (long)reader[0],
                EvidencijaKursa = new EvidencijaKursa
                {
                    IdEvidencija = (long)reader[1]
                },
                DatumOdrzavanja = (DateTime)reader[2],
                Cena = (double)reader[3],
                Cas = new Cas
                {
                    IdCas = (long)reader[4],
                    TemaCasa = (string)reader[5],
                    Modul = (string)reader[6]
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new StavkaEvidencijeKursa
                {
                    Rb = (long)reader[0],
                    EvidencijaKursa = new EvidencijaKursa
                    {
                        IdEvidencija = (long)reader[1]
                    },
                    DatumOdrzavanja = (DateTime)reader[2],
                    Cena = (double)reader[3],
                    Cas = new Cas
                    {
                        IdCas = (long)reader[4],
                        TemaCasa = (string)reader[5],
                        Modul = (string)reader[6]
                    }
                });
            }
            return entiteti;
        }
    }
}
