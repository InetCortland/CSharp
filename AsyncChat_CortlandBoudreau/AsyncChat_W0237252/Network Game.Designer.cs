namespace AsyncChat_W0237252
{
    partial class Network_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Network_Game));
            this.menuNetworkGame = new System.Windows.Forms.MenuStrip();
            this.gamemenuNetworkGame = new System.Windows.Forms.ToolStripMenuItem();
            this.exitmenuNetworkGame = new System.Windows.Forms.ToolStripMenuItem();
            this.networkmenuNetworkGame = new System.Windows.Forms.ToolStripMenuItem();
            this.connectmenuNetworkGame = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectmenuNetworkGame = new System.Windows.Forms.ToolStripMenuItem();
            this.picFakeGame = new System.Windows.Forms.PictureBox();
            this.lblmessageinfo = new System.Windows.Forms.Label();
            this.txtSendbox = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblConverstation = new System.Windows.Forms.Label();
            this.txtConvo = new System.Windows.Forms.TextBox();
            this.menuNetworkGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFakeGame)).BeginInit();
            this.SuspendLayout();
            // 
            // menuNetworkGame
            // 
            this.menuNetworkGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamemenuNetworkGame,
            this.networkmenuNetworkGame});
            this.menuNetworkGame.Location = new System.Drawing.Point(0, 0);
            this.menuNetworkGame.Name = "menuNetworkGame";
            this.menuNetworkGame.Size = new System.Drawing.Size(897, 24);
            this.menuNetworkGame.TabIndex = 1;
            this.menuNetworkGame.Text = "menuStrip1";
            this.menuNetworkGame.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // gamemenuNetworkGame
            // 
            this.gamemenuNetworkGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitmenuNetworkGame});
            this.gamemenuNetworkGame.Name = "gamemenuNetworkGame";
            this.gamemenuNetworkGame.Size = new System.Drawing.Size(50, 20);
            this.gamemenuNetworkGame.Text = "Game";
            // 
            // exitmenuNetworkGame
            // 
            this.exitmenuNetworkGame.Name = "exitmenuNetworkGame";
            this.exitmenuNetworkGame.Size = new System.Drawing.Size(92, 22);
            this.exitmenuNetworkGame.Text = "Exit";
            this.exitmenuNetworkGame.Click += new System.EventHandler(this.exitmenuNetworkGame_Click);
            // 
            // networkmenuNetworkGame
            // 
            this.networkmenuNetworkGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectmenuNetworkGame,
            this.disconnectmenuNetworkGame});
            this.networkmenuNetworkGame.Name = "networkmenuNetworkGame";
            this.networkmenuNetworkGame.Size = new System.Drawing.Size(64, 20);
            this.networkmenuNetworkGame.Text = "Network";
            this.networkmenuNetworkGame.Click += new System.EventHandler(this.networkmenuNetworkGame_Click);
            // 
            // connectmenuNetworkGame
            // 
            this.connectmenuNetworkGame.Name = "connectmenuNetworkGame";
            this.connectmenuNetworkGame.Size = new System.Drawing.Size(152, 22);
            this.connectmenuNetworkGame.Text = "Connect";
            this.connectmenuNetworkGame.Click += new System.EventHandler(this.connectmenuNetworkGame_Click);
            // 
            // disconnectmenuNetworkGame
            // 
            this.disconnectmenuNetworkGame.Name = "disconnectmenuNetworkGame";
            this.disconnectmenuNetworkGame.Size = new System.Drawing.Size(152, 22);
            this.disconnectmenuNetworkGame.Text = "Disconnect";
            this.disconnectmenuNetworkGame.Click += new System.EventHandler(this.disconnectmenuNetworkGame_Click);
            // 
            // picFakeGame
            // 
            this.picFakeGame.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picFakeGame.ErrorImage")));
            this.picFakeGame.Image = ((System.Drawing.Image)(resources.GetObject("picFakeGame.Image")));
            this.picFakeGame.InitialImage = ((System.Drawing.Image)(resources.GetObject("picFakeGame.InitialImage")));
            this.picFakeGame.Location = new System.Drawing.Point(0, 27);
            this.picFakeGame.Name = "picFakeGame";
            this.picFakeGame.Size = new System.Drawing.Size(897, 236);
            this.picFakeGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFakeGame.TabIndex = 2;
            this.picFakeGame.TabStop = false;
            // 
            // lblmessageinfo
            // 
            this.lblmessageinfo.AutoSize = true;
            this.lblmessageinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmessageinfo.Location = new System.Drawing.Point(56, 282);
            this.lblmessageinfo.Name = "lblmessageinfo";
            this.lblmessageinfo.Size = new System.Drawing.Size(150, 15);
            this.lblmessageinfo.TabIndex = 3;
            this.lblmessageinfo.Text = "Type your messages here.";
            // 
            // txtSendbox
            // 
            this.txtSendbox.Location = new System.Drawing.Point(59, 308);
            this.txtSendbox.Name = "txtSendbox";
            this.txtSendbox.Size = new System.Drawing.Size(688, 20);
            this.txtSendbox.TabIndex = 0;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Location = new System.Drawing.Point(753, 305);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(90, 23);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblConverstation
            // 
            this.lblConverstation.AutoSize = true;
            this.lblConverstation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConverstation.Location = new System.Drawing.Point(57, 354);
            this.lblConverstation.Name = "lblConverstation";
            this.lblConverstation.Size = new System.Drawing.Size(78, 15);
            this.lblConverstation.TabIndex = 6;
            this.lblConverstation.Text = "Conversation";
            // 
            // txtConvo
            // 
            this.txtConvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvo.Location = new System.Drawing.Point(59, 373);
            this.txtConvo.Multiline = true;
            this.txtConvo.Name = "txtConvo";
            this.txtConvo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConvo.Size = new System.Drawing.Size(784, 156);
            this.txtConvo.TabIndex = 7;
            // 
            // Network_Game
            // 
            this.AcceptButton = this.btnSendMessage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 559);
            this.Controls.Add(this.txtConvo);
            this.Controls.Add(this.lblConverstation);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtSendbox);
            this.Controls.Add(this.lblmessageinfo);
            this.Controls.Add(this.picFakeGame);
            this.Controls.Add(this.menuNetworkGame);
            this.MainMenuStrip = this.menuNetworkGame;
            this.Name = "Network_Game";
            this.Text = "Network_Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Network_Game_FormClosing);
            this.Load += new System.EventHandler(this.Network_Game_Load);
            this.menuNetworkGame.ResumeLayout(false);
            this.menuNetworkGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFakeGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem gamemenuNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem networkmenuNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem exitmenuNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem connectmenuNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem disconnectmenuNetworkGame;
        private System.Windows.Forms.PictureBox picFakeGame;
        private System.Windows.Forms.Label lblmessageinfo;
        private System.Windows.Forms.TextBox txtSendbox;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblConverstation;
        private System.Windows.Forms.TextBox txtConvo;
    }
}