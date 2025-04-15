using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_pacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[,]{
                            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                            { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#' },
                            { '#', ' ', ' ', ' ', ' ', ' ', '#', '#', ' ', '#', '#', '#' },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                         };

            int playerX = 1;
            int playerY = 1;
            int dX = 0;
            int dY = 0;
            const int applesNumber = 5;
            int applesCollected = 0;
            Random rand = new Random();
            ConsoleKey keyPressed = ConsoleKey.DownArrow;

            for (int i = 0; i < applesNumber; i++) {
                int aX = rand.Next(0, map.GetLength(1));
                int aY = rand.Next(0, map.GetLength(0));
                if (map[aY, aX] == ' ')
                    map[aY, aX] = '.';
                else
                    i--;
            }
            Console.CursorVisible = false;


            Task.Run(() =>
            {
                while (true) {
                    keyPressed = Console.ReadKey().Key;
                }
            });

            while (true) {
                //Console.Clear();
                Console.SetCursorPosition(map.GetLength(1) + 2, 0);
                Console.Write($"Scores: {applesCollected}");

                DrawMap(map);

                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write('@');
                Console.ForegroundColor = defaultColor;

                
                HandleKeys(keyPressed, map, ref playerX, ref playerY, ref dX, ref dY);

                if (map[playerY, playerX] == '.') {
                    map[playerY, playerX] = ' ';
                    applesCollected++;
                }

                Thread.Sleep(100);
            }
        }

        private static void DrawMap(char[,] map)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.GetLength(0); y++) {
                for (int x = 0; x < map.GetLength(1); x++)
                    Console.Write(map[y, x]);
                Console.WriteLine();
            }
            Console.ForegroundColor= defaultColor;
        }

        private static void HandleKeys(ConsoleKey key, char[,] map, ref int playerX, ref int playerY, ref int dX, ref int dY)
        {
            dX = 0;
            dY = 0;
            switch (key) {
                case ConsoleKey.LeftArrow:
                    dX = -1;
                    break;
                case ConsoleKey.RightArrow:
                    dX = 1;
                    break;
                case ConsoleKey.UpArrow:
                    dY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    dY = 1;
                    break;
            }

            if(map[playerY + dY, playerX + dX]  != '#') {
                playerX += dX;
                playerY += dY;
            }
        }
    }
}
