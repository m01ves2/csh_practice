using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_spaceInvaders
{
    internal class GameSettings
    {
        public int ConsoleWidth {get; set;} = 80;
        public int ConsoleHeight { get; set; } = 30;

        public int AliensRows { get; set; } = 2;
        public int AliensCols { get; set; } = 60;
        public int AliensStartX { get; set; } = 10;
        public int AliensStartY { get; set; } = 2;
        public char AlienFigure { get; set; } = 'O';
        public int AliensSpeed { get; set; } = 20;


        public int playerX { get; set; } = 40;
        public int playerY { get; set; } = 28;
        public char playerFigure { get; set; } = 'W';

        public char Ground { get; set; } = 'T';
        public int GroundStartX { get; set; } = 0;
        public int GroundStartY { get; set; } = 29;
        public int GroundRows { get; set; } = 1;
        public int GroundCols { get; set;} = 80;

        public char MissileFigure { get; set; } = '|';
        public int MissileSpeed { get; set; } = 5;

        public int GameSpeed { get; set; } = 100;
    }
}
