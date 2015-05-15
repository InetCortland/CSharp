using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Grass : GameObjects
    {
        /// <summary>
        /// Location that the water spawns
        /// </summary>
        public Grass(Rectangle gameplayArea)
        {
            displayArea.X = 0;
            displayArea.Y = 0;

            displayArea.Height = gameplayArea.Height / 9 - 3;
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
                Image newImage = Image.FromFile(@"Z:\GitHub\CSharp\PROG 2200\Frogger\Frogger\FrogGoal.png");
                // Create point for upper-left corner of image. 
                PointF ulCorner = new PointF(displayArea.X, displayArea.Y-45);
                // Draw image to screen.
                graphics.DrawImage(newImage, ulCorner);
                //graphics.FillRectangle(brush, displayArea);
            }



        }


    }
}
