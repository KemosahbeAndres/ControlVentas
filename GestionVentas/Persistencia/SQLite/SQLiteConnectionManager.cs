using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario.Persistence.SQLite
{
    class SQLiteConnectionManager
    {
        private static SQLiteConnection instance;

        public static SQLiteConnection getConnection()
        {
            if(instance == null)
            {
                instance = new SQLiteConnection();
            }
            return instance;
        }
    }
}
