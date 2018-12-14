using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using MySql.Data.MySqlClient;

namespace Vue
{

    public partial class Controller : Form
    {
        MySqlConnection Connect = new MySqlConnection(@"datasource=Localhost;port=3306;username=root;database=restaurant");
        MySqlCommand Command = new MySqlCommand();
        MySqlDataReader Reader;

        public Controller()
        {
            InitializeComponent();
            Deplacement.Start();
            perso.Start();
            perso.Interval = 5000;
            //Chefderangf.ImageLocation = @"C:\Users\MBOW\Documents\GitHub\Projet-Resto-C-\simulationRestaurant\Vue\Sprite\Chefderang\front.gif";

            //Chefdecuisineb.Location = Chefdecuisinef.Location;
            initpersonnage(Chefpartief, Chefpartieb);
            initpersonnage(Chefdecuisinef, Chefdecuisineb);
            initpersonnage(Chefderangf, Chefderangb, Chefderangd, Chefderangg);
            initpersonnage(Clientf, Clientb, Client, Clientg, Clientp);
            initpersonnage(Commiscuisinef, Commiscuisineb, Commiscuisined, Commiscuisineg);
            initpersonnage(Plongeursf, Plongeursb, Plongeursd, Plongeursg);
            initpersonnage(Commisf, Commisb, Commisd, Commisg);


            ////////////////////////////////Base de Données ////////////////////////////////
            Command.Connection = Connect;
            loadTable();
            loadFroid();
            loadCongel();
            loadMateriel();
            loadReserve();


            laver.laver(Connect,Command,Reader);




        }

        Laver laver = new Laver();
        private void loadMateriel()
        {
            dataGridView4.Rows.Clear();
            DataGridViewColumn columnMateriel = dataGridView4.Columns[0];
            columnMateriel.Width = 60;
            DataGridViewColumn columnStock = dataGridView4.Columns[1];
            columnStock.Width = 40;
            Connect.Open();
            Command.CommandText = "SELECT Type_Materiel, Quantite_Materiel FROM materiel INNER JOIN stocke ON materiel.ID_Materiel = stocke.ID_Materiel ";
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {


                while (Reader.Read())
                {

                    dataGridView4.Rows.Add(Reader[0].ToString(), Reader[1].ToString());

                }
                Connect.Close();
            }
        }

        // c'est la m�thode pour  afficher la table Stock d'aliment pour la r�serve  sur l'interface 
        private void loadReserve()
        {

            dataGridView2.Rows.Clear();
            DataGridViewColumn columnAliment = dataGridView2.Columns[0]; // je selectionne la premi�re colonne correspondant � la datagridview 2 (Reserve)
            columnAliment.Width = 60; // this sa augmente la longueur de la colonne de 60
            DataGridViewColumn columnStock = dataGridView2.Columns[1];
            columnStock.Width = 40; // ca augmente la longueur de la colonne de 40
            Connect.Open();
            Command.CommandText = "SELECT Nom_Aliment, Quantite_Aliment FROM aliment INNER JOIN stockage ON aliment.ID_Stockage = stockage.ID_Stockage WHERE stockage.Type_Stockage = 'reserve' ";
            Reader = Command.ExecuteReader();//c'est le buffer qui va contenir le resultat de la requete
            if (Reader.HasRows)
            {

                while (Reader.Read())
                {

                    dataGridView2.Rows.Add(Reader[0].ToString(), Reader[1].ToString());

                }
                Connect.Close();
            }
        }

        // c'est la m�thode pour afficher la table Stock d'aliment  pour le cong�lateur sur l'interface
        private void loadCongel()
        {
            dataGridView2.Rows.Clear();
            DataGridViewColumn columnAliment = dataGridView3.Columns[0];
            columnAliment.Width = 60;
            DataGridViewColumn columnStock = dataGridView3.Columns[1];
            columnStock.Width = 40;
            Connect.Open();
            Command.CommandText = "SELECT Nom_Aliment, Quantite_Aliment FROM aliment INNER JOIN stockage ON aliment.ID_Stockage = stockage.ID_Stockage WHERE stockage.Type_Stockage = 'congelateur' ";
            Reader = Command.ExecuteReader();//c'est le buffer qui va contenir le resultat de la requete
            if (Reader.HasRows)//Si il a une valeur � lire fait ce qu'il y a � l'int�rieur
            {

                while (Reader.Read())// tant qu'il a quelque chose � lire  fait sa
                {

                    dataGridView3.Rows.Add(Reader[0].ToString(), Reader[1].ToString());// chaque ligne de la premi�re et deuxi�me colonne sera stock� dans le datagrid de la Cong�lation

                }
                Connect.Close();
            }
        }



        // c'est la m�thode pour afficher la table Stock d'aliment  pour la chambre froide sur l'interface
        private void loadFroid()
        {
            dataGridView5.Rows.Clear();
            DataGridViewColumn columnAliment = dataGridView5.Columns[0];
            columnAliment.Width = 60;
            DataGridViewColumn columnStock = dataGridView5.Columns[1];
            columnStock.Width = 40;
            Connect.Open();
            Command.CommandText = "SELECT Nom_Aliment, Quantite_Aliment FROM aliment INNER JOIN stockage ON aliment.ID_Stockage = stockage.ID_Stockage WHERE stockage.Type_Stockage = 'chambre froide' ";
            Reader = Command.ExecuteReader();//c'est le buffer qui va contenir le resultat de la requete
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {

                    dataGridView5.Rows.Add(Reader[0].ToString(), Reader[1].ToString());

                }
                Connect.Close();
            }
        }

        private void loadgrid5()
        {

        }

        // c'est la m�thode pour  afficher la table tableronde  sur l'interface 
        private void loadTable()
        {

            dataGridView6.Rows.Clear();
            DataGridViewColumn colum1 = dataGridView6.Columns[0];
            DataGridViewColumn colum2 = dataGridView6.Columns[1];
            DataGridViewColumn colum3 = dataGridView6.Columns[2];
            colum1.Width = 40;
            colum2.Width = 40;
            colum3.Width = 40;
            Connect.Open();
            Command.CommandText = "SELECT Numero_Table, Nbr_Place, Disponibilite From tableronde;";
            Reader = Command.ExecuteReader();//c'est le buffer qui va contenir le resultat de la requete
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    dataGridView6.Rows.Add(Reader[0].ToString(), Reader[1].ToString(), Reader[2].ToString());
                }
                Connect.Close();
            }
        }

        public Point loc = new Point();

        public void sprite(int w, int direction)
        {
            /// 1 = en haut
            /// 2 = en bas
            /// 3 = à droite
            /// 4 = à gauche 
            
            switch (w)
            {
                case 1:
                    // maitre d'hotel
                    break;
                case 2:
                    // chef de rang
                    switch (direction)
                    {
                        case 1:
                            
                            Chefderangf.Visible = true;
                            Chefderangb.Visible = false;
                            Chefderangd.Visible = false;
                            Chefderangg.Visible = false;
                            break;
                        case 2:
                            Chefderangf.Visible = false;
                            Chefderangb.Visible = true;
                            Chefderangd.Visible = false;
                            Chefderangg.Visible = false;
                            break;
                        case 3:
                            Chefderangf.Visible = false;
                            Chefderangb.Visible = false;
                            Chefderangd.Visible = true;
                            Chefderangg.Visible = false;
                            break;
                        case 4:
                            Chefderangf.Visible = false;
                            Chefderangb.Visible = false;
                            Chefderangd.Visible = false;
                            Chefderangg.Visible = true;
                            break;
                    }
                    break;
                case 3:
                    // serveurs
                    switch (direction)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case 4:
                    // commis
                    switch (direction)
                    {
                        case 1:
                            Commisf.Visible = true;
                            Commisb.Visible = false;
                            Commisd.Visible = false;
                            Commisg.Visible = false;
                            break;
                        case 2:
                            Commisf.Visible = false;
                            Commisb.Visible = true;
                            Commisd.Visible = false;
                            Commisg.Visible = false;
                            break;
                        case 3:
                            Commisf.Visible = false;
                            Commisb.Visible = false;
                            Commisd.Visible = true;
                            Commisg.Visible = false;
                            break;
                        case 4:
                            Commisf.Visible = false;
                            Commisb.Visible = false;
                            Commisd.Visible = false;
                            Commisg.Visible = true;
                            break;
                    }
                    break;
                case 5:
                    //chef de cuisines 
                    switch (direction)
                    {
                        case 1:
                            Chefdecuisinef.Visible = true;
                            Chefdecuisineb.Visible = false;
                            break;
                        case 2:
                            Chefdecuisinef.Visible = !true;
                            Chefdecuisineb.Visible = !false;
                            break;
                        
                    }
                    break;

                case 6:
                    //chef de partif
                    switch (direction)
                    {
                        case 1:
                            Chefpartief.Visible = true;
                            Chefpartieb.Visible = !true;
                            break;
                        case 2:
                            Chefpartief.Visible = !true;
                            Chefpartieb.Visible = true;
                            break;
                        
                    }
                    break;
                case 7:
                    //commis cuisine
                    switch (direction)
                    {
                        case 1:
                            Commiscuisinef.Visible = !false;
                            Commiscuisineb.Visible = false;
                            Commiscuisined.Visible = false;
                            Commiscuisineg.Visible = false;
                            break;
                        case 2:
                            Commiscuisinef.Visible = false;
                            Commiscuisineb.Visible = !false;
                            Commiscuisined.Visible = false;
                            Commiscuisineg.Visible = false;
                            break;
                        case 3:
                            Commiscuisinef.Visible = false;
                            Commiscuisineb.Visible = false;
                            Commiscuisined.Visible = !false;
                            Commiscuisineg.Visible = false;
                            break;
                        case 4:
                            Commiscuisinef.Visible = false;
                            Commiscuisineb.Visible = false;
                            Commiscuisined.Visible = false;
                            Commiscuisineg.Visible = !false;
                            break;
                    }
                    break;
                case 8:
                    //plongeur
                    switch (direction)
                    {
                        case 1:
                            Plongeursf.Visible = !false;
                            Plongeursb.Visible = false;
                            Plongeursd.Visible = false;
                            Plongeursg.Visible = false;
                            break;
                        case 2:
                            Plongeursf.Visible = false;
                            Plongeursb.Visible = !false;
                            Plongeursd.Visible = false;
                            Plongeursg.Visible = false;
                            break;
                        case 3:
                            Plongeursf.Visible = false;
                            Plongeursb.Visible = false;
                            Plongeursd.Visible = !false;
                            Plongeursg.Visible = false;
                            break;
                        case 4:
                            Plongeursf.Visible = false;
                            Plongeursb.Visible = false;
                            Plongeursd.Visible = false;
                            Plongeursg.Visible = !false;
                            break;
                    }
                    break;
                case 9:
                   
                        switch (direction)
                        {
                        case 1:
                            Clientf.Visible = !false;
                            Clientb.Visible = false;
                            Client.Visible = false;
                            Clientg.Visible = false;
                            Clientp.Visible = false;
                            break;
                        case 2:
                            Clientf.Visible = false;
                            Clientb.Visible = !false;
                            Client.Visible = false;
                            Clientg.Visible = false;
                            Clientp.Visible = false;
                            break;
                        case 3:
                            Clientf.Visible = false;
                            Clientb.Visible = false;
                            Client.Visible = !false;
                            Clientg.Visible = false;
                            Clientp.Visible = false;
                            break;
                        case 4:
                            Clientf.Visible = false;
                            Clientb.Visible = false;
                            Client.Visible = false;
                            Clientg.Visible = !false;
                            Clientp.Visible = false;
                            break;
                        case 5:
                            Clientf.Visible = false;
                            Clientb.Visible = false;
                            Client.Visible = false;
                            Clientg.Visible = false;
                            Clientp.Visible = !false;
                            break;
                    }
                    break;
            }
        }
        public void initpersonnage(PictureBox p1, PictureBox p2, PictureBox p3, PictureBox p4, PictureBox p5)
        {
            PictureBox[] personnage = new PictureBox[]{ p1, p2, p3, p4, p5 };
         
            //Point loc = new Point();
            loc = personnage[0].Location;
            for (int i = 0; i < personnage.Length; i++)
            {
                personnage[i].Location = loc;
                personnage[i].Visible = false;
            }

            p1.Visible = true;


        }
        public void initpersonnage(PictureBox p1, PictureBox p2, PictureBox p3, PictureBox p4)
        {
            PictureBox[] personnage = new PictureBox[] { p1, p2, p3, p4 };

            //Point loc = new Point();
            loc = personnage[0].Location;
            for (int i = 0; i < personnage.Length; i++)
            {
                personnage[i].Location = loc;
                personnage[i].Visible = false;
            }
            p1.Visible = true;
        }

        public void initpersonnage(PictureBox p1, PictureBox p2)
        {
            PictureBox[] personnage = new PictureBox[] { p1, p2 };

            
            
                personnage[1].Location =  personnage[0].Location;
                personnage[1].Visible = false;
                personnage[0].Visible = true;

        }
        

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox472_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox398_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox505_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox507_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox516_Click(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void setDirectionAnimation(PictureBox thePicture,string filename)
        {
            thePicture.Image = Image.FromFile(filename);
            thePicture.BackColor = Color.Transparent;
            //thePicture.Image = Properties.Resources.hamster;
            //thePicture.Refresh();
           
        }

       public void changeSprite2(PictureBox image,PictureBox image2)
        {
            if (!image.Visible)
            {
                image.Visible = true;
                image2.Visible = false;
            }
            else
            {
                image.Visible = !true;
                image2.Visible = !false;
            }
        }

        public static bool IsNullOrEmpty(Array array)
        {
            return (array == null || array.Length == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personnage"></param>
        /// <param name="arrive"></param>
        /// <param name="speed"></param>

        public void deplacer(PictureBox[] personnage,Point arrive, int speed)
        {
            

            if (personnage[3].Location.X < arrive.X)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = !true;
                personnage[2].Visible = !true;
                personnage[3].Visible = true;
                personnage[3].Left += speed;
                personnage[0].Location = personnage[3].Location;
                personnage[2].Location = personnage[3].Location;
                personnage[3].Location = personnage[3].Location;

                //setDirectionAnimation(personnage, @"C:\Users\MBOW\Documents\GitHub\Projet-Resto-C-\simulationRestaurant\Vue\Sprite\Chefderang\gauche.gif");

            }
            else if (personnage[2].Location.X > arrive.X)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = !true;
                personnage[2].Visible = true;
                personnage[3].Visible = !true;
                personnage[2].Left -= speed;
                personnage[0].Location = personnage[2].Location;
                personnage[1].Location = personnage[2].Location;
                personnage[3].Location = personnage[2].Location;


            }
            if (personnage[1].Location.Y < arrive.Y)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = true;
                personnage[2].Visible = !true;
                personnage[3].Visible = !true;
                personnage[1].Top += speed;
                personnage[0].Location = personnage[1].Location;
                personnage[2].Location = personnage[1].Location;
                personnage[3].Location = personnage[1].Location;

            }
            else if (personnage[0].Location.Y > arrive.Y)
            {
                personnage[0].Visible = true;
                personnage[1].Visible = !true;
                personnage[2].Visible = !true;
                personnage[3].Visible = !true;
                personnage[0].Top -= speed;
                personnage[1].Location = personnage[0].Location;
                personnage[2].Location = personnage[0].Location;
                personnage[3].Location = personnage[0].Location;
            }


        }
        Commande commander = new Commande();
        PrendrePlace assoir = new PrendrePlace();
        public bool estArriveX,estArriveY; 
        private void timer1_Tick(object sender, EventArgs e)
        {

            //deplacer(Chefderangf, pictureBox547,1);
            //deplacer(new[] { Clientf, Clientb, Clientg, Client }, pictureBox261.Location, 1);

            deplacer(new[] { Clientf, Clientb, Clientg, Client }, assoir.prendrePlace(Connect, Command,  Reader), 1);

        }

        private void button_quitter_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }
        
        private void perso_Tick(object sender, EventArgs e)
        {
            

            changeSprite2(Chefdecuisinef, Chefdecuisineb);
        }

        private void pictureBox574_Click(object sender, EventArgs e)
        {

        }
        
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            loadTable();
            loadFroid();
            loadCongel();
            loadReserve(); //appel de la fonction loadgrid
            loadMateriel();
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }
    }
}
