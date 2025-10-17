using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Domen
{
    public class Sertifikat : IEntitet
    {
        public long IdSertifikat { get; set; }
        public string Naziv { get; set; }
        public string Institucija { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Sertifikat";

        [Browsable(false)]
        public string UbaciVrednosti => $"'{Naziv}','{Institucija}'";

        [Browsable(false)]
        public string IdName => "IdSertifikat";

        [Browsable(false)]
        public string JoinUslov => "";

        [Browsable(false)]
        public string Alias => "s";

        [Browsable(false)]
        public string Select =>"*";

        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";

        [Browsable(false)]
        public string UpdateVrednosti => $"Naziv='{Naziv}',Institucija='{Institucija}'";

        public override string ToString()
        {
            return $"{Naziv},{Institucija}";
        }

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Sertifikat
            {
                IdSertifikat = (long)reader[0],
                Naziv = (string)reader[1],
                Institucija = (string)reader[2],
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti=new List<IEntitet>();
            while (reader.Read()) {

                entiteti.Add(new Sertifikat
                {
                    IdSertifikat = (long)reader[0],
                    Naziv = (string)reader[1],
                    Institucija = (string)reader[2],
                });
            }
            return entiteti;
        }
    }
}
