using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders.GameObjectFactories
{
    internal class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject groundObject = new Ground()
            {
                Figure = GameSettings.Ground,
                GameObjectPlace = gameObjectPlace,
                GameObjectType = GameObjectType.Ground,
            };

            return groundObject;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();
            int startX = GameSettings.GroundStartX;
            int startY = GameSettings.GroundStartY;

            for (int y = 0; y < GameSettings.GroundRows; y++) {
                for (int x = 0; x < GameSettings.GroundCols; x++) {
                    GameObjectPlace gameObjectPlace = new GameObjectPlace(startX + x, startY + y);
                    GameObject groundObject = GetGameObject(gameObjectPlace);
                    ground.Add(groundObject);
                }
            }
            return ground;
        }
    }
}
