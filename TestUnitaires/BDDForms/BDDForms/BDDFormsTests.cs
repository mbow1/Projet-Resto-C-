using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BDDTest
{
    [TestFixture]
    class BDDFormsTests
    {
        /*****Check if path to the database works*****/
        [TestCase]
        public void Right_Path()
        {
            /***** Those two values will be check *****/
            string path_test = "datasource=Localhost;port=3306;username=root;password=;database=personne";
            string path_conn = "datasource=Localhost;port=3306;username=root;password=;database=personne";
            /***** path to create error *****/
            //string path_test = "datasource=Localhost;port=3306;username=root;password=;database=restaurant";
            try
            {
                /***** this try, check if tested connection path corresponds perfectly with scheduled path *****/
                Assert.AreEqual(path_conn, path_test);
                /***** if it's the case, create the connection *****/
                MySqlConnection Connect = new MySqlConnection(path_test);
                /***** Open a connection to our database *****/
                Connect.Open();
                /***** Notify connexion has been executed *****/
                MessageBox.Show("connexion has been executed");
                /***** Close the connection *****/
                Connect.Close();
            }
            catch
            {
                /***** If assert send error, display a error messagebox *****/
                /***** Test Failure *****/
                MessageBox.Show("error");
            }
        }



        /*****Check if database exists*****/
        [TestCase]
        public void Database_exits_test()
        {
            /***** create variable to the connection *****/
            MySqlConnection Connect = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=;database=personne");
            /**** Initialize variable for command *****/
            MySqlCommand Command = new MySqlCommand();
            //***** Bind command to the connection *****/
            Command.Connection = Connect;
            /***** Open a connection to our database *****/
            Connect.Open();
            /**** Initialize variable to prepare query *****/
            string QuerySQL = "CREATE DATABASE restaurant";
            try
            {
                //***** Bind a query to a command *****/
                Command.CommandText = QuerySQL;
                /***** Execute the query *****/
                Command.ExecuteNonQuery();
                MessageBox.Show("Database doesn't exits, creation");
                /***** Close the connection *****/
                Connect.Close();
            }
            catch (Exception ex)
            {
                /***** If assert send error, display a error messagebox *****/
                /***** Test Failure *****/
                MessageBox.Show("Database exits");
                MessageBox.Show(ex.Message);
                /***** Close the connection *****/
                Connect.Close();
            }
        }




        [TestCase]
          public void Querytest1() //DELETE FROM `personne` WHERE prénom = 'Dylan'
        {

            /***** Initialize variable to the connection *****/
            MySqlConnection Connect = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=;database=personne");
            /**** Initialize variable for command *****/
            MySqlCommand Command = new MySqlCommand();

            /**** Initialize variables to prepare query *****/
            string nom = "Bruce-Cimbert";
            string prénom = "Dylan";
            string adresse = "18 Rue Saint Ouen";
            string fonction = "Lead Dev";

            /**** Initialize variables for query *****/
            string QuerySQL = "INSERT INTO personne VALUES ('" + nom + "','" + prénom + "','" + adresse + "','" + fonction + "')";
            string QuerySQL2 = "SELECT * FROM personne WHERE nom = " + nom + " AND prénom = " + prénom + " AND adresse = " + adresse + " AND fonction = " + fonction + " ";
            //string QuerySQL3 = "SELECT * FROM personne WHERE nom = 'Wayne' AND prénom = 'Bruce' AND adresse = '18 Rue Gotham' AND fonction = 'Batman' ";

            //***** Bind command to the connection *****/
            Command.Connection = Connect;
            /***** Open a connection to our database *****/
            Connect.Open();
            /***** Execute the query *****/
            Command.ExecuteNonQuery();
            /***** Close the connection *****/
            Connect.Close();

            /***** Open a connection to our database *****/
            Connect.Open();


            //***** Bind a query to a command *****/
            Command.CommandText = QuerySQL2;
            //Command.CommandText = QuerySQL3;
            string remplissage = "test";

            MySqlDataReader Reader;
            Reader = Command.ExecuteReader();
            
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Reader[0].ToString();
                    remplissage = Convert.ToString(Reader[0]);

                }
                string[] rempli = remplissage.Split(',');
                string rempli0 = rempli[0];
                string rempli1 = rempli[1];
                //string rempli2 = rempli[2];
                //string rempli3 = rempli[3];
            }
                try
            {
                /***** Close the connection *****/
                Connect.Close();
            }
              catch (Exception ex)
              {
                MessageBox.Show("Fatal Error, record doesn't exist");
                MessageBox.Show(ex.Message);
                /***** Close the connection *****/
                Connect.Close();
            }
          }

    }
}
