using System;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Cuisiner
    {
        public void cuisiner(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            Connect.Open();
            string[] nom_Materiel = new string[] { "assiette", "fourchette", "couteaux", "cuillère a soupe", "cuillère à café", @"Verre d'eau", "Verre de vin", "Serviettes", "Nappes", "Casseroles", "Feux de cuisson", "Poêles", "Four", "Cuillères en bois", "Bols à salade", "Autocuiseur", "Presse-agrumes", "Tamis, Entonnoirs", "Couteaux de cuisine" };

            Random i = new Random();

            int j = i.Next(0, 19);

            Connect.Open();
            Command.CommandText = "UPDATE stocke INNER JOIN materiel ON materiel.ID_Materiel = stocke.ID_Materiel SET stocke.Quantite_Materiel=stocke.Quantite_Materiel-1 WHERE materiel.Type_Materiel = '" + nom_Materiel[j] + "'";
            Reader = Command.ExecuteReader();
            Connect.Close();
        }
    }
}
