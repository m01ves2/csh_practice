using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders.GameObjectFactories
{
    internal class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject playerShip = new PlayerShip()
            {
                Figure = GameSettings.playerFigure,
                GameObjectPlace = gameObjectPlace,
                GameObjectType = GameObjectType.PlayerShip,
            };
            return playerShip;
        }

        public GameObject GetGameObject()
        {
            GameObjectPlace gameObjectPlace = new GameObjectPlace(GameSettings.playerX, GameSettings.playerY);
            GameObject playerShip = GetGameObject(gameObjectPlace);
            return playerShip;
        }
    }
}
