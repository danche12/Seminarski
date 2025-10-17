using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domen
{
    public interface IEntitet
    {
        string ImeTabele { get; }    
        string UbaciVrednosti { get; }
        string IdName { get; }
        string JoinUslov { get; }
        string Alias { get; }
        string Select { get; }
        string WhereUslov { get; }
        string UpdateVrednosti { get; }
        List<IEntitet> VratiVise(SqlDataReader reader);
        IEntitet VratiJednog(SqlDataReader reader);
    }
}
