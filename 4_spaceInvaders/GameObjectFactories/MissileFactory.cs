using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders.GameObjectFactories
{
    internal class MissileFactory : GameObjectFactory
    {
        public MissileFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject missile = new Missile()
            {
                Figure = GameSettings.MissileFigure,
                GameObjectPlace = gameObjectPlace,
                GameObjectType = GameObjectType.Missile,
            };

            return missile;
        }
    }
}
