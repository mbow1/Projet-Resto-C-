using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace Model
{
    public class Position
    {
        private int m_x;
        public int x
        {
            get { return m_x; }
            set { m_x = value; }
        }
        
        private int m_y;
        public int y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public Position(int x, int y)
        {
            this.m_x = x;
            this.m_y = y;
        }
        /*implementation of Position class.*/
        public void move()
        {
            /*current point of the character*/
            Point pos = new Point(x, y);
            /*destination point of the character*/
            Point nextPos = new Point();
            /*move method.*/
            while (x != nextPos.X)
            {
                if (x < nextPos.X)
                {
                    x++;
                }
                else if (x > nextPos.X)
                {
                    x--;
                }
            }
            /*the character moves on the x axe*/
            while (y != nextPos.Y)
            {
                if (y < nextPos.Y)
                {
                    y++;
                }
                else if (y > nextPos.Y)
                {
                    y--;
                }
            }
            /*the character moves on the y axe*/
        }

    }
}
