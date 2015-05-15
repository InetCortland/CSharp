using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Car : GameObjects
    {
        private Color randomColor;
        private static readonly Random random = new Random();
       public static Image newImage = Image.FromFile(@"Z:\GitHub\CSharp\PROG 2200\Frogger\Frogger\car.png");

        /// <summary>
        /// Where the car objects spawn based on a passed in row
        /// </summary>
        public Car(Rectangle gameplayArea, int row)
        {
            Random random = new Random();

            while(XVelocity > -15 && XVelocity < 1)
               XVelocity = random.Next(-15, 0);
            //while (YVelocity > -3 && YVelocity < 3)
             //   YVelocity = random.Next(-20, 20);

            displayArea.Height = 45;
            displayArea.Width = 90;

              switch (row)
            {
                case 1:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height /2+300 - this.displayArea.Height / 2;

                        break;
                    }
                case 2:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height / 2 + 200 - this.displayArea.Height / 2;

                        break;
                    }
                case 3:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height / 2  + 100 - this.displayArea.Height / 2;

                        break;
                    }
                case 4:
                    {
                        displayArea.X = gameplayArea.Width - 11 - this.displayArea.Width / 2;
                        displayArea.Y = gameplayArea.Height / 2  - this.displayArea.Height / 2;

                        break;
                    }
           
            }
           randomColor = GetRandomColor();

        }

        /// <summary>
        /// Draw method for the car
        /// </summary>
        public new void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(randomColor))
            {

                // Create point for upper-left corner of image. 
                PointF ulCorner = new PointF(displayArea.X, displayArea.Y);
                // Draw image to screen.
                graphics.DrawImage(newImage, ulCorner);
                //graphics.FillRectangle(brush, displayArea);
            }
        }
        /// <summary>
        /// Gives a sudo random color for the cars
        /// </summary>
        private Color GetRandomColor()
        {
            return Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));

        }

        public  void ClearImage() 
        {

            newImage.Dispose();
        
        }

    }
}
