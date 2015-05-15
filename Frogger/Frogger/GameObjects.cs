using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public abstract class GameObjects
    {
        public Rectangle displayArea;
        public int leftBound;
        public int rightBound;
        public int botBound;
        public int topBound;
        public int XVelocity = 0;
        public static string dir = Path.GetDirectoryName(Application.ExecutablePath);
       

        /// <summary>
        /// sets and gets for xvelocity
        /// </summary>
        public int xvelocity
        {
            get { return XVelocity; }
            set { XVelocity = value; }
        }


        /// <summary>
        ///  enum for easy directions
        /// </summary>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }


        /// <summary>
        /// Default move
        /// </summary>
        public void Move() 
        {
            displayArea.X += XVelocity;
        }

        /// <summary>
        /// Default draw
        /// </summary>
       public void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(brush, displayArea);
            }
        }


       /// <summary>
       /// returns the display area rectangle
       /// </summary>
       public Rectangle DisplayArea
       {
           get
           {
               return displayArea;
           }
       }

    }
}
