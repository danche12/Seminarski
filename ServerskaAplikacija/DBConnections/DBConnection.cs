using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.DBConnections
{
    public class DBConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public void OpenConnection()
        {
            if (!IsReady())
            {
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Seminarski;Integrated Security=True;");
                connection.Open();  
            }
        }

        public SqlCommand CreateCommand(string sql="")
        {
            if (transaction == null)
            {
                transaction=connection.BeginTransaction();
            }
            return new SqlCommand(sql, connection,transaction); 
        }

        public void Commit()
        {
            transaction?.Commit();  
        }
        public void Rollback()
        {
            transaction?.Rollback();
        }
        
        public bool IsReady()
        {
            return connection != null && connection.State!=ConnectionState.Closed;
        }

        public void Close()
        {
            connection?.Close();
            transaction?.Dispose();
            transaction = null;
        }
    }
}
