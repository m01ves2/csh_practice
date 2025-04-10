using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_stroller
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
            const int appleNumber = 5;
            int appleCollected = 0;

            map[playerY, playerX] = '@';

            Random rand = new Random();
            for (int i = 0; i < appleNumber; i++) {
                int aX = rand.Next(0, map.GetLength(1));
                int aY = rand.Next(0, map.GetLength(0));
                if (map[aY, aX] == ' ')
                    map[aY, aX] = '.';
                else
                    i--;
            }

            Console.CursorVisible = false;
            while (true) {
                //Console.Clear();
                Console.SetCursorPosition(map.GetLength(1) + 2, 0);
                Console.Write($"Scores: {appleCollected}");

                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < map.GetLength(0); y++) {
                    for (int x = 0; x < map.GetLength(1); x++)
                        Console.Write(map[y, x]);
                    Console.WriteLine();
                }

                int playerOldX = playerX;
                int playerOldY = playerY;
                ConsoleKey key = Console.ReadKey().Key;
                switch (key) {
                    case ConsoleKey.LeftArrow:
                        playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        break;
                    case ConsoleKey.UpArrow:
                        playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        playerY++;
                        break;
                }

                if (map[playerY, playerX] == '#') {
                    playerX = playerOldX;
                    playerY = playerOldY;
                }
                else {
                    map[playerOldY, playerOldX] = ' ';
                    if (map[playerY, playerX] == '.') {
                        appleCollected++;
                    }
                    map[playerY, playerX] = '@';
                }
            }

;        }
    }
}
