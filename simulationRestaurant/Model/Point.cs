using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
    }
}