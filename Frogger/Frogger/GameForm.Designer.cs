namespace Frogger
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.CarsSpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.LogsSpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 33;
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // CarsSpawnTimer
            // 
            this.CarsSpawnTimer.Interval = 400;
            this.CarsSpawnTimer.Tick += new System.EventHandler(this.CarsSpawnTimer_Tick);
            // 
            // LogsSpawnTimer
            // 
            this.LogsSpawnTimer.Interval = 1400;
            this.LogsSpawnTimer.Tick += new System.EventHandler(this.LogsSpawnTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(954, 502);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Cortland Boudreau\'s Frogger";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer CarsSpawnTimer;
        private System.Windows.Forms.Timer LogsSpawnTimer;
    }
}

