using System.Drawing;
using System.Threading;
using MySql.Data.MySqlClient;


namespace Model
{
    public class PrendrePlace
    {
        /*
         * 
                 * 122; 500
                122; 309
                213; 309
                --- hall d'entree
                 256; 341

                 ---- premire table de 2 places

                 213; 447
                 275; 447

                 ----- table de 4 place
                 424; 309
                 425; 391
                 ----- table 8 place

                 604; 309
                 601; 417

                --- table 10 places
         * */



        public Point prendrePlace(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            Connect.Open();
            Command.CommandText = "SELECT Numero_Table FROM restaurant.tableronde WHERE Disponibilite = 1 LIMIT 1";
            Reader = Command.ExecuteReader();
            Reader.Read();
            if (Reader[0].ToString() == "1")
            {
                Connect.Close();
                return new Point(273, 337);
            }
            else if (Reader[0].ToString() == "2")
            {
                Connect.Close();
                return new Point(275, 447);
            }
            else if (Reader[0].ToString() == "3")
            {
                Connect.Close();
                return new Point(425, 391);
            }
            else if (Reader[0].ToString() == "4")
            {
                Connect.Close();
                return new Point(601, 417);
            }
            else
            {
                Connect.Close();
                return new Point(213, 309);
            }
           
        }

        public Point partirClient(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            Thread.Sleep(30*1000);
            return new Point(93, 500);
        }
    }
}
