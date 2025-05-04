using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_spaceInvadersWFA
{
    internal class Render
    {

        public static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedPicture)) {
                graphics.DrawImage(picture, 0, 0, width, height);
            }
            return resizedPicture;
        }

        public void PaintAliens()
        {

        }

        public void PaintPlayerShip()
        {

        }

        public void PaintGround()
        {

        }

        public void PaintMissles()
        {

        }
    }
}
