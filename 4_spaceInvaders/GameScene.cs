using System;
using System.Collections.Generic;
using _4_spaceInvaders.GameObjectFactories;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders
{
    internal class GameScene
    {
        //private char[,] field;

        public GameObject playerShip;
        public List<GameObject> playerMisiles;
        public List<GameObject> alienShips;
        public List<GameObject> grounds;

        private GameSettings _gameSettings;
        private static GameScene _scene = null;
        private GameScene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            alienShips = (new AlienShipFactory(_gameSettings)).GetAliens();
            grounds = (new GroundFactory(_gameSettings)).GetGround();
            playerShip = (new PlayerShipFactory(_gameSettings)).GetGameObject();
            playerMisiles = new List<GameObject>();
        }

        public static GameScene GetScene(GameSettings gameSettings)
        {
            if (_scene == null) {
                _scene = new GameScene(gameSettings);
            }
            return _scene;
        }
    }
}
