using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIS_Assignment4.DataAcess
{

    public class CrimesDatabase : IDisposable
    {
        public MySqlConnection Connection;

        public CrimesDatabase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Connection.ConnectionString = "server=localhost; database=Crimes; uid=root; pwd=123;";
            
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
