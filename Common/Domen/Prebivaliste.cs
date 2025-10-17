using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Domen
{
    [Serializable]
    public class Prebivaliste : IEntitet
    {
        public long IdPrebivaliste { get; set; }
        public string NazivMesta { get; set; }
        public long PostanskiBroj { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Prebivaliste";

        [Browsable(false)]
        public string UbaciVrednosti =>$" '{NazivMesta}', '{PostanskiBroj}'";

        [Browsable(false)]
        public string IdName => "IdPrebivaliste";

        [Browsable(false)]
        public string JoinUslov => "";

        [Browsable(false)]
        public string Alias => "pr";

        [Browsable(false)]
        public string Select => "*";

        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";

        [Browsable(false)]
        public string UpdateVrednosti => $"NazivMesta='{NazivMesta}',PostanskiBroj={PostanskiBroj}";

        public override string ToString()
        {
            return $"{NazivMesta},{PostanskiBroj}";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Prebivaliste
            {
                IdPrebivaliste = (long)reader[0],
                NazivMesta = (string)reader[1],
                PostanskiBroj=(long)reader[2],
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new Prebivaliste
                {
                    IdPrebivaliste = (long)reader[0],
                    NazivMesta = (string)reader[1],
                    PostanskiBroj = (long)reader[2],
                });

            }
            return entiteti;
        }
        
    }
}
