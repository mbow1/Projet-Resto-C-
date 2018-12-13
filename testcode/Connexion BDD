using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Model
{
    public class BDDConnector
    {
        MySqlConnection Connect = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=dylan;database=restaurant");
        MySqlCommand Command = new MySqlCommand();
        MySqlDataReader Reader;
        public void Connection()
        {
            MySqlConnection Connect = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=dylan;database=restaurant");
            Connect.Open();
        }
       public void SQLCommand()
        {
            MySqlCommand Command = new MySqlCommand();
        }

        /*
        private SqlConnection _connection;
        private DataSet _dataSet;
        private string _connectionString;
        public BDDConnector()
        {
            try
            {
                _connectionString = "datasource=Localhost;port=3306;username=root;password=dylan;database=restaurant";

                _connection = new SqlConnection(_connectionString);
                _dataSet = new DataSet();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not start @" + System.DateTime.Now.ToString());
                Console.WriteLine(e);
            }


        }
        */
    }
}
