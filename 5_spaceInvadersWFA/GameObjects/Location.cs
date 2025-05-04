using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_spaceInvadersWFA.GameObjects
{
    internal class Location
    {
        public int X {  get; set; }
        public int Y { get; set; }
        Bitmap Image { get; set; }
        
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
