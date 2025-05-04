using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders.GameObjectFactories
{
    internal class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject alienShip = new AlienShip()
            {
                Figure = GameSettings.AlienFigure,
                GameObjectPlace = gameObjectPlace,
                GameObjectType = GameObjectType.AlienShip,
            };

            return alienShip;
        }

        public List<GameObject> GetAliens()
        {
            List<GameObject> aliens = new List<GameObject>();
            int startX = GameSettings.AliensStartX;
            int startY = GameSettings.AliensStartY;

            for (int y = 0; y < GameSettings.AliensRows; y++) {
                for (int x = 0; x < GameSettings.AliensCols; x++) {
                    GameObjectPlace gameObjectPlace = new GameObjectPlace(startX + x, startY + y);
                    GameObject alienShip = GetGameObject(gameObjectPlace);
                    aliens.Add(alienShip);
                }
            }
            return aliens;
        }
    }
}
