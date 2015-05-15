using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Log : GameObjects
    {


        /// <summary>
        ///  Log Spawn point
        /// </summary>
       public Log(Rectangle gameplayArea, int row)
        {
           
            Random random = new Random();

            while (XVelocity > -5 && XVelocity < 1)
               XVelocity = random.Next(-5, 0);

            displayArea.Height = 50;
            displayArea.Width = 150;

           switch (row)
            {
                case 1:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height  /2 -99 - this.displayArea.Height / 2;
                       
                        break;
                    }
                case 2:
                    {
                        displayArea.X = gameplayArea.Width - gameplayArea.Width + 5 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height / 2 - 153 - this.displayArea.Height / 2;
                        this.XVelocity = this.XVelocity * -1;
                        break;
                    }
                case 3:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height / 2 - 206 - this.displayArea.Height / 2;
                        break;
                    }

              }



        }

       /// <summary>
       ///  Draw method for the log
       /// </summary>
        public new void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(204, 153, 0, 0)))
            {

                Image newImage = Image.FromFile(@"Z:\GitHub\CSharp\PROG 2200\Frogger\Frogger\log.png");
                // Create point for upper-left corner of image. 
                PointF ulCorner = new PointF(displayArea.X-50, displayArea.Y);
                // Draw image to screen.
                graphics.DrawImage(newImage, ulCorner);
                //graphics.FillRectangle(brush, displayArea);
            }
        }

    }
}
