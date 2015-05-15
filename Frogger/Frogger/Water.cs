using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Water : GameObjects
    {

         /// <summary>
        /// Location that the water spawns
        /// </summary>
        public Water(Rectangle gameplayArea)
        {
            displayArea.X = 0;
            displayArea.Y = gameplayArea.Height / 4 + 10;

            displayArea.Height = gameplayArea.Height / 6 - 44;
            displayArea.Width = gameplayArea.Width;

        }

        /// <summary>
        ///  Draw method to give the water color
        /// </summary>
        public new void Draw(Graphics graphics)
        {
            Color color = Color.Cyan;

            using (SolidBrush brush = new SolidBrush(color))
            {
                Image newImage = Image.FromFile(@"Z:\GitHub\CSharp\PROG 2200\Frogger\Frogger\Water.png");
                // Create point for upper-left corner of image. 
                PointF ulCorner = new PointF(displayArea.X, displayArea.Y-25);
                // Draw image to screen.
                graphics.DrawImage(newImage, ulCorner);
                //graphics.FillRectangle(brush, displayArea);
            }



        }


    }
}
