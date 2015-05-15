using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Frogger
{
    public partial class GameForm : Form
    {
        Frog frog;
        Water theWater;
        Grass theGrass;
        int lastlane=0;
        int lastFlow = 0;
        bool onaLog = false;
        HashSet<Car> Cars = new HashSet<Car>();
        HashSet<Log> Logs = new HashSet<Log>();
        RectangleF endGameMessage;

        private bool gameOver = false;
        private bool winGame = false;
        public GameForm()
        {
            this.Text = "Cortland Boudreau Frogger";
            InitializeComponent();
        }

        /// <summary>
        /// Method to Adjust Window size to fullscreen
        /// </summary>
        private void AdjustSizeOfFormToFitScreen()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Paint method that belongs to the form, also controls other aspects of the game, movement
        /// Win/loss States
        /// </summary>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            theWater.Draw(e.Graphics); // draw the water
            theGrass.Draw(e.Graphics); // Draw the Grass
            foreach (var acar in Cars) // draw all the cars
            {
                acar.Draw(e.Graphics);
            }

            foreach (var alog in Logs) // draw all the logs
            {
                alog.Draw(e.Graphics);
            }

           frog.Draw(e.Graphics); // draw frog






             // Create font and brush.
            Font drawFont = new Font("Arial", 35);
            SolidBrush drawBrush = new SolidBrush(Color.Gold);
            //e.Graphics.DrawString(String.Format("Level:"), drawFont, drawBrush, 0, 0);
            
            if (gameOver && !winGame)
            {
                e.Graphics.DrawString("Game Over", 
                    drawFont, 
                    drawBrush, 
                    this.DisplayRectangle.Width / 2  -90, 
                    this.DisplayRectangle.Height / 2 - 50);
            }

            if(Cars.Count < 4 && !gameOver && !winGame)
                e.Graphics.DrawString("Starting Game....",
                    drawFont,
                    drawBrush,
                    this.DisplayRectangle.Width / 2 - 100,
                    this.DisplayRectangle.Height / 2 - 50);


            if (winGame)

            {
                e.Graphics.DrawString("You Win",
                drawFont,
                drawBrush,
                this.DisplayRectangle.Width / 2 - 100,
                this.DisplayRectangle.Height / 2 - 50);
            
            
            }


        }

        /// <summary>
        /// Keydown on the form, controls all character aspects
        /// Case setup for Left,right,up,down,spacebar
        /// Also helps control delay for Controls working
        /// </summary>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            int numCars =4;
     
                switch (e.KeyData.ToString())
                {
                    case "Left":
                        {
                            if (Cars.Count > numCars)
                            if (animationTimer.Enabled)
                                frog.Move(Frog.Direction.Left);
                            break;
                        }
                    case "Right":
                        {
                            if (Cars.Count > numCars)
                            if (animationTimer.Enabled)
                                frog.Move(Frog.Direction.Right);
                            break;
                        }
                    case "Space":
                        {
                            if (!gameOver)
                            {
                                if (animationTimer.Enabled && Cars.Count == 0)
                                    LoadCar();
                                else
                                    animationTimer.Start();
                            }

                            else
                            {
                                LoadCar();
                                animationTimer.Stop();
                                gameOver = !gameOver;
                                Invalidate();
                            }
                            if (!CarsSpawnTimer.Enabled)
                                CarsSpawnTimer.Start();
                            if (!LogsSpawnTimer.Enabled)
                                LogsSpawnTimer.Start();
                            break;
                            
                        }
                    case "Up":
                        {
                            if (Cars.Count > numCars)
                            if (animationTimer.Enabled)
                                frog.Move(Frog.Direction.Up);
                            break;
                        }
                    case "Down":
                        {
                            if (Cars.Count > numCars)
                            if (animationTimer.Enabled)
                                frog.Move(Frog.Direction.Down);
                            break;
                        }
             
            }


        }

        /// <summary>
        /// Load Method for the form, starts up and delcares different aspects of our program as well as loads the Frog
        /// and a car.
        /// </summary>
        private void GameForm_Load(object sender, EventArgs e)
        {
            Size size = new Size(200, 50);
            Point endGameMessageLocation = new Point((int)(this.DisplayRectangle.Width / 2 - size.Width / 2),
                                                     (int)(this.DisplayRectangle.Height / 2 - size.Height / 2));
            endGameMessage = new RectangleF(endGameMessageLocation, size);

            AdjustSizeOfFormToFitScreen();

            frog = new Frog(this.DisplayRectangle);
            theWater = new Water(this.DisplayRectangle);
            theGrass = new Grass(this.DisplayRectangle);
            LoadCar();
            LoadLog();


        }

        /// <summary>
        /// Loadlog method, loads logs into a Hashset
        /// It loads a log with a random number 1-3 which tells the car object where it spawns
        /// </summary>
        private void LoadLog()
        {
            Random rnd = new Random();
            int row = rnd.Next(1, 4);

            while (lastFlow == row)
            {
                row = rnd.Next(1, 4);
            }

            Logs.Add(new Log(this.DisplayRectangle, row));
            lastFlow = row;
        }

        /// <summary>
        /// LoadCar method, loads cars into a Hashset
        /// It loads a car with a random number 1-4 which tells the car object where it spawns
        /// </summary>
        private void LoadCar()
        {
            Random rnd = new Random();
            int row = rnd.Next(1, 5);

            while (lastlane == row)
            {
                row = rnd.Next(1, 5);
            }

            Cars.Add(new Car(this.DisplayRectangle, row));
            lastlane = row;
        }

        /// <summary>
        /// Animation timer handles Collisions, endgame check as well as movement and re-draw.
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            HandleCollisions();
            CheckForEndGame();

            foreach(Car cars in Cars)
            {
                cars.Move();
                
            }

            foreach (Log log in Logs)
            {
                log.Move();

            }
            frog.Move(); 
            Invalidate();
        }

        /// <summary>
        /// Checks for the end of the game, if its over it resets the frog and clears the cars.
        /// </summary>
        private void CheckForEndGame()
        {

            if (gameOver) 
            {

                Logs.Clear();
                Cars.Clear();
                CarsSpawnTimer.Stop();
                animationTimer.Stop();
                LogsSpawnTimer.Stop();
                frog.ResetFrog();
            }
        }

        /// <summary>
        /// Handle Collisions checks to see where the cars touch the frog, as well as provide a win condition
        /// and cleans up cars that pass the screen
        /// </summary>
        private void HandleCollisions()
        {
            
            Cars.RemoveWhere(CarPasses);
            Logs.RemoveWhere(LogPasses);


            if (FrogFinish(frog)) 
            {
                gameOver = true;
            }

           foreach (Car acar in Cars)
              {
                    if (FrogContacts(acar))
                    {
                        gameOver = true;
                    }
                }

           foreach (Log alog in Logs)
                {
                    if (FrogContacts(alog))
                    {
                        frog.xvelocity = alog.XVelocity;
                        onaLog = true;
                        break;
                    }
                    frog.xvelocity = 0;
                    onaLog = false;
                }

           FrogContacts(theWater);



        }

        /// <summary>
        /// If the frog contacts the water and we aren't on a log its gameover
        /// </summary>
        private void FrogContacts(Water theWater)
        {


            if (theWater.DisplayArea.IntersectsWith(frog.DisplayArea))
            {
                if (onaLog == false)
                {
                    gameOver = true;
                }
               
            }
        }

        /// <summary>
        /// If a frog hits a car this will return true or false
        /// </summary>
        private bool FrogContacts(Car acar)
        {
            return acar.DisplayArea.IntersectsWith(frog.DisplayArea);
        }

        /// <summary>
        /// If a frog hits a log this will return true or false
        /// </summary>
        private bool FrogContacts(Log alog)
        {
            bool Intersect = alog.DisplayArea.IntersectsWith(frog.DisplayArea);

            if (Intersect)
            {
                if (frog.DisplayArea.X > alog.DisplayArea.X - 7 && frog.DisplayArea.X < alog.DisplayArea.X + 137)
                {
                    return true;
                }

            }
            return false;

                

             //    {
             //        if (alog.DisplayArea.X < frog.DisplayArea.X) // frog is right of log
             //        {
             //            return true;
             //        }

             //        else if (alog.DisplayArea.X == frog.DisplayArea.X +20) // frog is left of log
             //        {
             //            return true;
             //        }

             //        return false;
             //    }
             //return false;

                
        }

        /// <summary>
        /// If a car passes the screen it will be deleted, this method just checks if it passes the left or right side
        /// </summary>
        private bool CarPasses(Car acar)
        {

            if (acar.DisplayArea.Right <= this.DisplayRectangle.Left)
            {
                return acar.DisplayArea.Right <= this.DisplayRectangle.Left;
            }

            if (acar.DisplayArea.Left >= this.DisplayRectangle.Right)
            {
                return acar.DisplayArea.Left >= this.DisplayRectangle.Right;
            }

            return false;
        }


        /// <summary>
        /// If a log passes the screen it will be deleted, this method just checks if it passes the left or right side
        /// </summary>
        private bool LogPasses(Log alog)
        {


            if (alog.DisplayArea.Right <= this.DisplayRectangle.Left)
                return alog.DisplayArea.Right <= this.DisplayRectangle.Left;

            if (alog.DisplayArea.Left >= this.DisplayRectangle.Right)
                return alog.DisplayArea.Left >= this.DisplayRectangle.Right;

            return false;
        }

        /// <summary>
        /// This checks if the frog makes it to the top side of the map
        /// </summary>
        private bool FrogFinish(Frog afrog)
        {
            if (afrog.DisplayArea.Top <= this.DisplayRectangle.Top)
            {
                winGame = true; return winGame;
            }
            else
                winGame = false; return winGame;

        }

        /// <summary>
        /// Car spawn timer loads a car in every so often
        /// </summary>
        private void CarsSpawnTimer_Tick(object sender, EventArgs e)
        {
            if (animationTimer.Enabled)
            {
                LoadCar();
                
            }
        }


        /// <summary>
        /// Log spawn timer loads a log in every so often
        /// </summary>
        private void LogsSpawnTimer_Tick(object sender, EventArgs e)
        {
           if (animationTimer.Enabled)
            {
                LoadLog();
            }
        }


    }
}
