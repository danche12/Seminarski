using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domen
{
    public class InstruktorSertifikat:IEntitet
    {
        public Instruktor Instruktor { get; set; }
        public Sertifikat Sertifikat { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Uslov { get; set; }
        public string ImeTabele => "InstruktorSertifikat";

        public string UbaciVrednosti => $"{Instruktor.IdInstruktor},{Sertifikat.IdSertifikat},'{DatumIzdavanja:yyyy-MM-dd}'";

        public string IdName => "Id";

        public string JoinUslov => "Join Instruktor i on (i.IdInstruktor=is.Instruktor)" + "Join Sertifikat s on (s.IdSertifikat=is.Sertifikat)";

        public string Alias => "is";

        public string Select => "*";

        public string WhereUslov => $"{Uslov}";

        public string UpdateVrednosti => $"DatumIzdavanja='{DatumIzdavanja:yyyy-MM-dd}'";


        public override string ToString()
        {
            return $"{DatumIzdavanja}";
        }
        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new InstruktorSertifikat
            {
                Instruktor = (Instruktor)reader[0],
                Sertifikat = (Sertifikat)reader[1],
                DatumIzdavanja = (DateTime)reader[2]
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti=new List<IEntitet>();
            while (reader.Read()) {

                entiteti.Add(new InstruktorSertifikat
                {
                    Instruktor = (Instruktor)reader[0],
                    Sertifikat = (Sertifikat)reader[1],
                    DatumIzdavanja = (DateTime)reader[2]
                });
            
            }
            return entiteti;    
        }
    }
}
