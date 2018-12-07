using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Acteur
    {
        int id;
        float speed;

        Position pos = new Position(0,0);
        /*Sprite sprit = new Sprite();*/

    }
}
