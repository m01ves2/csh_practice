using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjectFactories;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders
{
    internal class GameEngine //singleton
    {
        private static GameEngine _gameEngine;
        private bool _isNotGameOver;
        private GameScene _scene;
        private GameRenderer _renderer;
        private GameSettings _gameSettings;

        private GameEngine(GameSettings gameSettings) {
            _isNotGameOver = true;
            _scene = GameScene.GetScene(gameSettings);
            _renderer = new GameRenderer(gameSettings);
            _gameSettings = gameSettings;
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null) {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }

        int aliensMoveCounter = 0;
        int missileMoveCounter = 0;
        public void Run()
        {
            do {
                _renderer.Render(_scene);

                aliensMoveCounter++;
                if (aliensMoveCounter == _gameSettings.GameSpeed / 10) {
                    MoveAliens();
                    aliensMoveCounter = 0;
                }

                missileMoveCounter++;
                if(missileMoveCounter == _gameSettings.MissileSpeed) {
                    MoveMissiles();
                    missileMoveCounter = 0;
                }

                Thread.Sleep(_gameSettings.GameSpeed);

            }while (_isNotGameOver);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_gameSettings.ConsoleWidth/2 - 10, _gameSettings.ConsoleHeight/2);
            _renderer.DoGameOver();
        }

        public void MovePlayerShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.X > 1) {
                _scene.playerShip.GameObjectPlace.X--;
            }
        }

        public void MovePlayerShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.X < _gameSettings.ConsoleWidth - 1) {
                _scene.playerShip.GameObjectPlace.X++;
            }
        }

        private void MoveAliens()
        {
            foreach (var alien in _scene.alienShips) {
                
                alien.GameObjectPlace.Y++;

                if (alien.GameObjectPlace.Y == _scene.playerShip.GameObjectPlace.Y) {
                    _isNotGameOver = false;
                }

            }
        }

        private void MoveMissiles()
        {
            for (int i = 0; i < _scene.playerMisiles.Count; i++) {
                GameObject missile = _scene.playerMisiles[i];
                missile.GameObjectPlace.Y--;

                if (missile.GameObjectPlace.Y <= 0) {
                    _scene.playerMisiles.Remove(missile);
                }

                for (int j = 0; j < _scene.alienShips.Count; j++) {
                    GameObject alienShip = _scene.alienShips[j];
                    if (alienShip.GameObjectPlace.Equals(missile.GameObjectPlace)) {
                        _scene.playerMisiles.Remove(missile);
                        _scene.alienShips.Remove(alienShip);
                        break;
                    }
                }
            }
        }
        
        public void Shot()
        {
            GameObjectPlace missilePlace = new GameObjectPlace(_scene.playerShip.GameObjectPlace.X,
                                                               _scene.playerShip.GameObjectPlace.Y - 1);

            GameObject missile = (new MissileFactory(_gameSettings)).GetGameObject(missilePlace);
            _scene.playerMisiles.Add(missile);
            Console.Beep(1000, 200);
        }
    }
}
