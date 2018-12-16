using System;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Commande
    {
        public void commander(MySqlConnection Connect, MySqlCommand Command, MySqlDataReader Reader)
        {
            
            string menuChoisi = choix_aleatoire(); // menuChoisi take the menu ramdomly chosen by the choix_aleatoire method

           
            Connect.Open();
           // Command.CommandText = "SELECT Description_Menu FROM menu WHERE Nom_Menu = '" + menuChoisi + "'";
            Command.CommandText = "SELECT Description_Menu FROM menu WHERE Nom_Menu = 'crevettes '";
            string listeIngredient = "test";
            Reader = Command.ExecuteReader();//c'est le buffer qui va contenir le resultat de la requete
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Reader[0].ToString();
                    listeIngredient = Convert.ToString(Reader[0]); //convert result of query to a string
                }
                Connect.Close();
            }

            string[] ingredient = listeIngredient.Split(','); //we separate list of ingredients between , and stock them in string. 

            for (int i = 0; i < ingredient.Length; i++)
            {
                Command.CommandText = "UPDATE aliment SET Quantite_Aliment = Quantite_Aliment - 1 WHERE Nom_Aliment = " + ingredient[i] + " AND Quantite_Aliment > 0;";
            }
            
        }
        public string choix_aleatoire()
        {
            string nomMenu;
            Random aleatoire = new Random();
            int menuAleatoire = aleatoire.Next(29); //generate a number between 0 and 29 because we have 30 menues

            if (menuAleatoire == 0) //we associate eah number a menu
            {
                nomMenu = "Ile flottante";
                return (nomMenu);
            }
            else if (menuAleatoire == 1)
            {
                nomMenu = "Salade";
                return (nomMenu);
            }
            else if (menuAleatoire == 2)
            {
                nomMenu = "Melon";
                return (nomMenu);
            }
            else if (menuAleatoire == 3)
            {
                nomMenu = "Jambon";
                return (nomMenu);
            }
            else if (menuAleatoire == 4)
            {
                nomMenu = "Pate";
                return (nomMenu);
            }
            else if (menuAleatoire == 5)
            {
                nomMenu = "Oeufs dur";
                return (nomMenu);
            }
            else if (menuAleatoire == 6)
            {
                nomMenu = "Taboule";
                return (nomMenu);
            }
            else if (menuAleatoire == 7)
            {
                nomMenu = "Gaspacho";
                return (nomMenu);
            }
            else if (menuAleatoire == 8)
            {
                nomMenu = "Saumon fume";
                return (nomMenu);
            }
            else if (menuAleatoire == 9)
            {
                nomMenu = "Galette de crabe";
                return (nomMenu);
            }
            else if (menuAleatoire == 10)
            {
                nomMenu = "Quiche epinards";
                return (nomMenu);
            }
            else if (menuAleatoire == 11)
            {
                nomMenu = "Couscous";
                return (nomMenu);
            }
            else if (menuAleatoire == 12)
            {
                nomMenu = "Colombo";
                return (nomMenu);
            }
            else if (menuAleatoire == 13)
            {
                nomMenu = "Crevettes";
                return (nomMenu);
            }
            else if (menuAleatoire == 14)
            {
                nomMenu = "Steak Frites";
                return (nomMenu);
            }
            else if (menuAleatoire == 15)
            {
                nomMenu = "Alokot";
                return (nomMenu);
            }
            else if (menuAleatoire == 16)
            {
                nomMenu = "Poulet basquaise";
                return (nomMenu);
            }
            else if (menuAleatoire == 17)
            {
                nomMenu = "Poele legumes";
                return (nomMenu);
            }
            else if (menuAleatoire == 18)
            {
                nomMenu = "Spaghetti";
                return (nomMenu);
            }
            else if (menuAleatoire == 19)
            {
                nomMenu = "Lasagnes";
                return (nomMenu);
            }
            else if (menuAleatoire == 20)
            {
                nomMenu = "Mac and Cheese";
                return (nomMenu);
            }
            else if (menuAleatoire == 21)
            {
                nomMenu = "Tiramisu";
                return (nomMenu);
            }
            else if (menuAleatoire == 22)
            {
                nomMenu = "Sorbet";
                return (nomMenu);
            }
            else if (menuAleatoire == 23)
            {
                nomMenu = "Macaron cafe";
                return (nomMenu);
            }
            else if (menuAleatoire == 24)
            {
                nomMenu = "Mousse framboise";
                return (nomMenu);
            }
            else if (menuAleatoire == 25)
            {
                nomMenu = "Banane split";
                return (nomMenu);
            }
            else if (menuAleatoire == 26)
            {
                nomMenu = "Tarte chocolat";
                return (nomMenu);
            }
            else if (menuAleatoire == 27)
            {
                nomMenu = "Tarte citron";
                return (nomMenu);
            }
            else if (menuAleatoire == 28)
            {
                nomMenu = "Tarte pommes";
                return (nomMenu);
            }
            else
            {
                nomMenu = "Salade fruit";
                return (nomMenu);
            }
        }
    }
}