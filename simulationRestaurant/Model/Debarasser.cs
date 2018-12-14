using MySql.Data.MySqlClient;

namespace Model
{
    public class Debarasser
    {
        public void debarasser(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            
            Connect.Open();
            Command.CommandText = "SELECT Numero_Table FROM restaurant.tableronde WHERE Disponibilite = 0 LIMIT 1";
            Reader = Command.ExecuteReader();
        }
    }
}
