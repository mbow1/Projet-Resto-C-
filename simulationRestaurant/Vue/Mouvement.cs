using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vue
{
    class Mouvement
    {
        public void mouvement(PictureBox[] personnage, Point[] arrive)
        {

            deplacer(personnage, arrive[0]);
            
            if (estArriveY && estArriveX)
            {
                estArriveX = false;
                estArriveY = false;
                deplacer(personnage, arrive[1]);
                if (estArriveY && estArriveX)
                {
                    estArriveX = false;
                    estArriveY = false;
                    deplacer(personnage, arrive[2]);
                    if (estArriveY && estArriveX)
                    {
                        estArriveX = false;
                        estArriveY = false;
                        deplacer(personnage, arrive[3]);
                        if (estArriveY && estArriveX && !arrive[4].IsEmpty)
                        {
                            estArriveX = false;
                            estArriveY = false;
                            deplacer(personnage, arrive[4]);
                            if (estArriveY && estArriveX && !arrive[5].IsEmpty)
                            {
                                estArriveX = false;
                                estArriveY = false;
                                deplacer(personnage, arrive[5]);
                            }
                        }
                    }
                }
            }
        }

        private bool estArriveX = false, estArriveY = false;
        public void deplacer(PictureBox[] personnage, Point arrive)
        {


            if (personnage[3].Location.X < arrive.X)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = !true;
                personnage[2].Visible = !true;
                personnage[3].Visible = true;
                personnage[3].Left += 1;
                personnage[0].Location = personnage[3].Location;
                personnage[2].Location = personnage[3].Location;
                personnage[3].Location = personnage[3].Location;

                if (personnage[3].Location.X == arrive.X)
                    estArriveX = true;

            }
            else if (personnage[2].Location.X > arrive.X)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = !true;
                personnage[2].Visible = true;
                personnage[3].Visible = !true;
                personnage[2].Left -= 1;
                personnage[0].Location = personnage[2].Location;
                personnage[1].Location = personnage[2].Location;
                personnage[3].Location = personnage[2].Location;
                if (personnage[2].Location.X == arrive.X)
                    estArriveX = true;

            }
            if (personnage[1].Location.Y < arrive.Y)
            {
                personnage[0].Visible = !true;
                personnage[1].Visible = true;
                personnage[2].Visible = !true;
                personnage[3].Visible = !true;
                personnage[1].Top += 1;
                personnage[0].Location = personnage[1].Location;
                personnage[2].Location = personnage[1].Location;
                personnage[3].Location = personnage[1].Location;
                if (personnage[1].Location.Y == arrive.Y)
                    estArriveY = true;


            }
            else if (personnage[0].Location.Y > arrive.Y)
            {
                personnage[0].Visible = true;
                personnage[1].Visible = !true;
                personnage[2].Visible = !true;
                personnage[3].Visible = !true;
                personnage[0].Top -= 1;
                personnage[1].Location = personnage[0].Location;
                personnage[2].Location = personnage[0].Location;
                personnage[3].Location = personnage[0].Location;
                if (personnage[0].Location.Y == arrive.Y)
                    estArriveY = true;
            }


        }


    }
}
