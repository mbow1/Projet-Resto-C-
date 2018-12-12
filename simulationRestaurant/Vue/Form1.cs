using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vue
{
    /*
    public class move
    {

        public void Move(PictureBox personnage1, PictureBox pictureBox547, int speed)
        {
            if (personnage1.Location.X < pictureBox547.Location.X)
            {
                personnage1.Left += speed;

            }
            else if (personnage1.Location.X > pictureBox547.Location.X)
            {
                personnage1.Left -= speed;
            }
            if (personnage1.Location.Y < pictureBox547.Location.Y)
            {
                personnage1.Top += speed;

            }
            else if (personnage1.Location.Y > pictureBox547.Location.Y)
            {
                personnage1.Top -= speed;
            }

        }
    }*/
    public partial class Form1 : Form
    {
        public Form1()
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
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="personnage"></param>
        /// <param name="arrive"></param>
        /// <param name="speed"></param>
        public void deplacer(PictureBox personnage,PictureBox arrive, int speed)
        {
            if (personnage.Location.X < arrive.Location.X)
            {
                personnage.Left += speed;
                
                    //setDirectionAnimation(personnage, @"C:\Users\MBOW\Documents\GitHub\Projet-Resto-C-\simulationRestaurant\Vue\Sprite\Chefderang\gauche.gif");

            }
            else if (personnage.Location.X > arrive.Location.X)
            {
                personnage.Left -= speed;
                
            }
            if (personnage.Location.Y < arrive.Location.Y)
            {
                personnage.Top += speed;
                
            }
            else if (personnage.Location.Y > arrive.Location.Y)
            {
                personnage.Top -= speed;
               
            }


        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            deplacer(Chefderangf, pictureBox547,1);

            
            

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

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }
    }
}
