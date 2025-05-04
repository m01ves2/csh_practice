using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_spaceInvaders.GameObjects
{
    internal class GameObjectPlace
    {

        public GameObjectPlace(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {  get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GameObjectPlace) {
                GameObjectPlace objPlace = (GameObjectPlace)obj;
                return X == objPlace.X && Y == objPlace.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
