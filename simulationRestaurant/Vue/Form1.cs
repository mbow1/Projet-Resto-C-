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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private int x, y;



        public Point MovePointTowards(Point a, Point b, double distance)
        {
            var vector = new Point(b.X - a.X, b.Y - a.Y);
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            var unitVector = new Point(Convert.ToInt32(vector.X / length), Convert.ToInt32 (vector.Y / length));
            return new Point(Convert.ToInt32(a.X + unitVector.X * distance), Convert.ToInt32( a.Y + unitVector.Y * distance));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            MovePointTowards(pictureBox1.Location,new Point(200,200),2000f);

            



        }
    }
}
