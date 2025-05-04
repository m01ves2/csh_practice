using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_spaceInvaders.GameObjects
{
    internal abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }
        public char Figure {  get; set; }
        public GameObjectType GameObjectType { get; set; }
    }
}
