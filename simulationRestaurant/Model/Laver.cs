using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Model
{

    public class Laver
    {

        MySqlConnection Connect = new MySqlConnection(@"datasource=Localhost;port=3306;username=root;password=' ';database=restaurant");
        MySqlCommand Command = new MySqlCommand();
        MySqlDataReader Reader;

        public void laver(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            string[] nom_Materiel = new string[] { "assiette", "fourchette", "couteaux", "cuillère a soupe", "cuillère à café", @"Verre d\'eau", "Verre de vin", "Serviettes", "Nappes", "Casseroles", "Feux de cuisson", "Poêles", "Four", "Cuillères en bois", "Bols à salade", "Autocuiseur", "Presse-agrumes", "Tamis, Entonnoirs", "Couteaux de cuisine" };

            Random i = new Random();

            int j = i.Next(0, 19);

            Connect.Open();
            Command.CommandText = "UPDATE stocke INNER JOIN materiel ON materiel.ID_Materiel = stocke.ID_Materiel SET stocke.Quantite_Materiel=stocke.Quantite_Materiel+1 WHERE materiel.Type_Materiel = '" + nom_Materiel[j] + "'";
            Reader = Command.ExecuteReader();
            Connect.Close();
        }
        }
}
