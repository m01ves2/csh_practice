using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_spaceInvadersWFA.GameObjects
{
    internal abstract class GameObject
    {
        public Location Location { get; set; }

        public GameObject(int x, int y)
        {
            Location = new Location(x, y);
        }
    }
}
