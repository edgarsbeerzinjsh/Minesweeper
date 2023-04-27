namespace Minesweeper
{
    partial class Minesweeper
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
            this.timeCounter = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flagCounter = new System.Windows.Forms.Label();
            this.resetGame = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timeCounter
            // 
            this.timeCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeCounter.BackColor = System.Drawing.SystemColors.ControlText;
            this.timeCounter.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCounter.ForeColor = System.Drawing.Color.Lime;
            this.timeCounter.Location = new System.Drawing.Point(328, 9);
            this.timeCounter.Name = "timeCounter";
            this.timeCounter.Size = new System.Drawing.Size(87, 53);
            this.timeCounter.TabIndex = 0;
            this.timeCounter.Text = "0";
            this.timeCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flagCounter
            // 
            this.flagCounter.BackColor = System.Drawing.SystemColors.ControlText;
            this.flagCounter.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagCounter.ForeColor = System.Drawing.Color.Lime;
            this.flagCounter.Location = new System.Drawing.Point(12, 9);
            this.flagCounter.Name = "flagCounter";
            this.flagCounter.Size = new System.Drawing.Size(87, 53);
            this.flagCounter.TabIndex = 1;
            this.flagCounter.Text = "0";
            this.flagCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetGame
            // 
            this.resetGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetGame.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resetGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.resetGame.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.resetGame.Location = new System.Drawing.Point(186, 13);
            this.resetGame.Name = "resetGame";
            this.resetGame.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resetGame.Size = new System.Drawing.Size(42, 49);
            this.resetGame.TabIndex = 2;
            this.resetGame.Text = "J";
            this.resetGame.UseVisualStyleBackColor = false;
            this.resetGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetGameButton);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 200;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(427, 551);
            this.Controls.Add(this.resetGame);
            this.Controls.Add(this.flagCounter);
            this.Controls.Add(this.timeCounter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label timeCounter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button resetGame;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label flagCounter;
    }
}

