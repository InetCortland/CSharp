using System;
using System.Drawing;
using System.IO;


namespace Frogger
{
    class Frog : GameObjects
    {

        private int startX;     // starting X
        private int startY;     // Starting y
        private static readonly int frogHeight = 26;   // height of frog
        private static readonly int frogWidth = 20;    // width of frog
        private static readonly int frogMovement = 30; // How far the frog moves

        
        /// <summary>
        /// Draw area of the Frog
        /// </summary>
        public Frog(Rectangle gameplayArea)
        {
            displayArea.Height = frogHeight;
            displayArea.Width = frogWidth;

            displayArea.X = gameplayArea.Width / 2 - this.displayArea.Width /2;
            displayArea.Y = gameplayArea.Bottom-30;

            startX = displayArea.X;
            startY = displayArea.Y;

            this.leftBound = gameplayArea.Left;
            this.rightBound = gameplayArea.Right;
            this.topBound = gameplayArea.Top;
            this.botBound = gameplayArea.Bottom;
           
        }

        /// <summary>
        /// Movement for the frog, Up down, left right
        /// </summary>
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (displayArea.X < 100)
                        {
                            displayArea.X = 0;
                        }
                        else
                        {
                            displayArea.X -= frogMovement;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (displayArea.X >= rightBound - displayArea.Width)
                        {
                            displayArea.X = rightBound - displayArea.Width;
                        }
                        else
                        {
                            displayArea.X += frogMovement;
                        }
                        break;
                    }

                case Direction.Up:
                     {
                        if (displayArea.Y <= topBound - displayArea.Height)
                        {
                            displayArea.Y = topBound - displayArea.Height;
                        }
                        else
                        {
                            displayArea.Y -= frogMovement;
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (displayArea.Y >= botBound - displayArea.Height)
                        {
                            displayArea.Y = botBound - displayArea.Height;
                        }
                        else
                        {
                            displayArea.Y += frogMovement;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Movement for the frog with Velocity
        /// </summary>
        public new void Move() 
        {

            if (displayArea.Y >= botBound - displayArea.Height)
            {
                displayArea.Y = botBound - displayArea.Height;
            }

            else if (displayArea.Y <= topBound - displayArea.Height)
            {
                displayArea.Y = topBound - displayArea.Height;
            }
            else if (displayArea.X >= rightBound - displayArea.Width)
            {
                displayArea.X = rightBound - displayArea.Width;
            }
            else if (displayArea.X <10)
            {
                displayArea.X = 0;
            }
            else
            {
                displayArea.X += xvelocity;
            }
        }

        /// <summary>
        /// Fills the Frog Rectangle with green color
        /// </summary>
        public new void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color.LawnGreen))
            {

                Image newImage = Image.FromFile(@"Z:\GitHub\CSharp\PROG 2200\Frogger\Frogger\frog2.png");
                // Create point for upper-left corner of image. 
                PointF ulCorner = new PointF(displayArea.X-20, displayArea.Y);
                // Draw image to screen.
                graphics.DrawImage(newImage, ulCorner);
                //graphics.FillRectangle(brush, displayArea);
            }
        }

        /// <summary>
        /// Resets Frogs position
        /// </summary>
        public void ResetFrog ()
        {
            displayArea.X = startX;
            displayArea.Y = startY;
        }



    }
}
