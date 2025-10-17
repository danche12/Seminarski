using ServerskaAplikacija.DBConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.Repozitorijum
{
    public interface IDBRepozitorijum<T> : IGenerickiRepo<T> where T : class 
    {
        void Commit()
        {
            DBConnection con = DBConnectionFactory.Instance.GetDBConnection();
            con.Commit();
        }
        void Rollback()
        {
            DBConnection con = DBConnectionFactory.Instance.GetDBConnection();
            con.Rollback();
        }
        void Close()
        {
            DBConnection con = DBConnectionFactory.Instance.GetDBConnection();
            con.Close();
        }
        void Open()
        {
            DBConnection con = DBConnectionFactory.Instance.GetDBConnection();
            con.OpenConnection();
        }
    }
    
}
