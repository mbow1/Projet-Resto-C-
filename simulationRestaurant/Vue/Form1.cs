using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteLibrary;

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
            personnage11.ImageLocation = @"C:\Users\MBOW\Documents\GitHub\Projet-Resto-C-\simulationRestaurant\Vue\Sprite\Chefderang\front.gif";

            Chefdecuisineback.Location = Chefdecuisinefront.Location;

            

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

            deplacer(personnage11, pictureBox547,1);

            
            

        }

        private void button_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void perso_Tick(object sender, EventArgs e)
        {
            

            changeSprite2(Chefdecuisinefront, Chefdecuisineback);
        }
    }
}
