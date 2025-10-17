using Common.Domen;
using Microsoft.Data.SqlClient;
using ServerskaAplikacija.DBConnections;
using System;
using System.Collections.Generic;

namespace ServerskaAplikacija.Repozitorijum
{
    public class GenerickiRepo: IDBRepozitorijum<IEntitet>
    {
       
        public void Close()
        {
            DBConnectionFactory.Instance.GetDBConnection().Close();
        }
        public void Commit()
        {
            DBConnectionFactory.Instance.GetDBConnection().Commit();
        }
        public long Dodaj(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
             $"insert into {entitet.ImeTabele} output inserted.{entitet.IdName} values ({entitet.UbaciVrednosti})");
            long newID = Convert.ToInt64(command.ExecuteScalar());
            return newID;
        }

        public void DodajBezId(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
             $"insert into {entitet.ImeTabele} values ({entitet.UbaciVrednosti})");
            command.ExecuteScalar();
        }

        public void Obrisi(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
              $"delete from {entitet.ImeTabele} where {entitet.WhereUslov}");
            command.ExecuteNonQuery();
        }

      
        public void Open()
        {
            DBConnectionFactory.Instance.GetDBConnection().OpenConnection();
        }
        public void Rollback()
        {
            DBConnectionFactory.Instance.GetDBConnection().Rollback();
        }
        public void Promeni(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
             $"update {entitet.ImeTabele} set {entitet.UpdateVrednosti} where {entitet.WhereUslov}");
            command.ExecuteNonQuery();
        }
        public IEntitet VratiJednog(IEntitet entitet)
        {
            IEntitet pronadjeni = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
                  $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
           using(SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    pronadjeni = entitet.VratiJednog(reader);
                }
            }
            return pronadjeni;
        }

        public List<IEntitet> VratiPoUslovu(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
                  $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                entiteti = entitet.VratiVise(reader);
            }
            return entiteti;
        }

        public List<IEntitet> VratiSve(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDBConnection().CreateCommand(
                  $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov};");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                entiteti = entitet.VratiVise(reader);
            }
            return entiteti;
        }
    }
}
