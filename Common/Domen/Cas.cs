using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domen
{
    public class Cas : IEntitet
    {
        public long IdCas { get; set; }
        public string TemaCasa { get; set; }
        public double CenaCasa { get; set; }
        public long TrajanjeCasa { get; set; }
        public string Modul { get; set; }
        public string Uslov { get; set; }
        public string ImeTabele => "Cas";

        public string UbaciVrednosti => $"'{TemaCasa}',{CenaCasa},{TrajanjeCasa},'{Modul}'";

        public string IdName => "IdCas";

        public string JoinUslov => "";

        public string Alias =>"c";

        public string Select => "*";

        public string WhereUslov => $"{Uslov}";

        public string UpdateVrednosti => $"NazivCasa='{TemaCasa}',CenaCasa={CenaCasa},TrajanjeCasa={TrajanjeCasa},Modul='{Modul}'";

        public override string ToString()
        {
            return $"{TemaCasa}";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Cas
            {
                IdCas = (long)reader[0],
                TemaCasa = (string)reader[1],
                CenaCasa = (double)reader[2],
                TrajanjeCasa = (long)reader[3],
                Modul = (string)reader[4]
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read()) {

                entiteti.Add(new Cas
                {
                    IdCas = (long)reader[0],
                    TemaCasa = (string)reader[1],
                    CenaCasa = (double)reader[2],
                    TrajanjeCasa = (long)reader[3],
                    Modul = (string)reader[4]
                });
            }
            return entiteti;
        }
    }
}
