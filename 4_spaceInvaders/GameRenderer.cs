using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders
{
    internal class GameRenderer
    {
        private int _screenWidth;
        private int _screenHeight;
        private char[,] _screenMatrix;

        public GameRenderer(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _screenMatrix = new char[_screenHeight, _screenWidth];
            
            Console.WindowWidth = _screenWidth;
            Console.WindowHeight = _screenHeight;
            
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal void Render(GameScene scene)
        {
            ClearScreen();

            AddGameObjectForRendering(scene.playerShip);
            AddGameObjectListForRendering(scene.alienShips);
            AddGameObjectListForRendering(scene.grounds);
            AddGameObjectListForRendering(scene.playerMisiles);


            //Console.SetCursorPosition(0, 0);

            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWidth; x++) {
                    stringBuilder.Append(_screenMatrix[y, x]);
                    //Console.Write(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
                //Console.WriteLine();
            }

            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);

        }

        private void ClearScreen() //просто для очистки экрана
        {
            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWidth; x++) {
                    _screenMatrix[y, x] = ' ';
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.Y < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.Y >= 0 &&
                gameObject.GameObjectPlace.X < _screenMatrix.GetLength(1) &&
                gameObject.GameObjectPlace.X >= 0) {

                _screenMatrix[gameObject.GameObjectPlace.Y, gameObject.GameObjectPlace.X] = gameObject.Figure;
            }
        }

        public void AddGameObjectListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects) {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void DoGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("G A M E  O V E R !!!");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
