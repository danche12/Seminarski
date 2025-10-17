using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.DBConnections
{
    public class DBConnectionFactory
    {
        private static DBConnectionFactory instance;
        private DBConnection connection=new DBConnection();

        public static DBConnectionFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnectionFactory();
                }
                return instance;
            }
        }
        public DBConnectionFactory()
        {
                
        }
        public DBConnection GetDBConnection()
        {
            if (!connection.IsReady())
            {
                connection.OpenConnection();    
            }
            return connection;
        }
    }
}
