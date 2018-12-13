using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Point pt = new Point();


            return pt;
        }
    }
}
