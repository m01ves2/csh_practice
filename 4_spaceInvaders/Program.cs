using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4_spaceInvaders
{
    internal class Program
    {
        private static GameEngine _gameEngine;
        private static GameSettings _gameSettings;
        private static UIController _uIController;

        static void Main(string[] args)
        {
            Initialize();
            _gameEngine.Run();
        }

        private static void Initialize()
        {
            _gameSettings = new GameSettings();
            _gameEngine = GameEngine.GetGameEngine(_gameSettings);
            _uIController = new UIController();

            _uIController.OnAPressed += (obj, arg) => _gameEngine.MovePlayerShipLeft();
            _uIController.OnDPressed += (obj, arg) => _gameEngine.MovePlayerShipRight();
            _uIController.OnSpacePressed += (obj, arg) => _gameEngine.Shot();

            Thread uiThread = new Thread(_uIController.StartListen);
            uiThread.Start();
        }
    }
}
