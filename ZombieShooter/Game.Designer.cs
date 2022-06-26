﻿namespace ZombieShooter
{
    partial class Game
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
            this.txtAmmo = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.helthBarLabel = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOverBanner = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.titleGroup = new System.Windows.Forms.GroupBox();
            this.titlePic = new System.Windows.Forms.PictureBox();
            this.pressEnterLabel = new System.Windows.Forms.Label();
            this.arrowsToMove = new System.Windows.Forms.Label();
            this.spaceToShoot = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.titleGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmmo
            // 
            this.txtAmmo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.White;
            this.txtAmmo.Location = new System.Drawing.Point(364, 13);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(93, 24);
            this.txtAmmo.TabIndex = 0;
            this.txtAmmo.Text = "Ammo: 0";
            // 
            // txtScore
            // 
            this.txtScore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(1022, 13);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(88, 24);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Score: 0";
            // 
            // helthBarLabel
            // 
            this.helthBarLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.helthBarLabel.AutoSize = true;
            this.helthBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helthBarLabel.ForeColor = System.Drawing.Color.White;
            this.helthBarLabel.Location = new System.Drawing.Point(595, 12);
            this.helthBarLabel.Name = "helthBarLabel";
            this.helthBarLabel.Size = new System.Drawing.Size(70, 24);
            this.helthBarLabel.TabIndex = 2;
            this.helthBarLabel.Text = "Health";
            // 
            // healthBar
            // 
            this.healthBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.healthBar.Location = new System.Drawing.Point(672, 12);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(229, 23);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // GameOverBanner
            // 
            this.GameOverBanner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GameOverBanner.BackColor = System.Drawing.Color.Transparent;
            this.GameOverBanner.Image = global::ZombieShooter.Properties.Resources.GameOver;
            this.GameOverBanner.Location = new System.Drawing.Point(564, 198);
            this.GameOverBanner.Name = "GameOverBanner";
            this.GameOverBanner.Size = new System.Drawing.Size(356, 245);
            this.GameOverBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GameOverBanner.TabIndex = 5;
            this.GameOverBanner.TabStop = false;
            this.GameOverBanner.Visible = false;
            // 
            // player
            // 
            this.player.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::ZombieShooter.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(702, 449);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // titleGroup
            // 
            this.titleGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleGroup.AutoSize = true;
            this.titleGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.titleGroup.Controls.Add(this.titleText);
            this.titleGroup.Controls.Add(this.pressEnterLabel);
            this.titleGroup.Controls.Add(this.arrowsToMove);
            this.titleGroup.Controls.Add(this.spaceToShoot);
            this.titleGroup.Controls.Add(this.titlePic);
            this.titleGroup.Location = new System.Drawing.Point(12, 39);
            this.titleGroup.Name = "titleGroup";
            this.titleGroup.Size = new System.Drawing.Size(1460, 884);
            this.titleGroup.TabIndex = 11;
            this.titleGroup.TabStop = false;
            // 
            // titlePic
            // 
            this.titlePic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titlePic.Image = global::ZombieShooter.Properties.Resources.title_card;
            this.titlePic.Location = new System.Drawing.Point(230, 71);
            this.titlePic.Name = "titlePic";
            this.titlePic.Size = new System.Drawing.Size(1000, 562);
            this.titlePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.titlePic.TabIndex = 7;
            this.titlePic.TabStop = false;
            // 
            // pressEnterLabel
            // 
            this.pressEnterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pressEnterLabel.AutoSize = true;
            this.pressEnterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressEnterLabel.ForeColor = System.Drawing.Color.Maroon;
            this.pressEnterLabel.Location = new System.Drawing.Point(619, 709);
            this.pressEnterLabel.Name = "pressEnterLabel";
            this.pressEnterLabel.Size = new System.Drawing.Size(222, 29);
            this.pressEnterLabel.TabIndex = 13;
            this.pressEnterLabel.Text = "ENTER to START";
            // 
            // arrowsToMove
            // 
            this.arrowsToMove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.arrowsToMove.AutoSize = true;
            this.arrowsToMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrowsToMove.ForeColor = System.Drawing.Color.Maroon;
            this.arrowsToMove.Location = new System.Drawing.Point(597, 670);
            this.arrowsToMove.Name = "arrowsToMove";
            this.arrowsToMove.Size = new System.Drawing.Size(267, 29);
            this.arrowsToMove.TabIndex = 12;
            this.arrowsToMove.Text = "ARROW keys to move";
            // 
            // spaceToShoot
            // 
            this.spaceToShoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spaceToShoot.AutoSize = true;
            this.spaceToShoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceToShoot.ForeColor = System.Drawing.Color.Maroon;
            this.spaceToShoot.Location = new System.Drawing.Point(594, 636);
            this.spaceToShoot.Name = "spaceToShoot";
            this.spaceToShoot.Size = new System.Drawing.Size(272, 29);
            this.spaceToShoot.TabIndex = 11;
            this.spaceToShoot.Text = "Press SPACE to shoot";
            // 
            // titleText
            // 
            this.titleText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.Transparent;
            this.titleText.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.DarkRed;
            this.titleText.Location = new System.Drawing.Point(207, 0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(0, 68);
            this.titleText.TabIndex = 14;
            this.titleText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.titleText.UseMnemonic = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1474, 824);
            this.Controls.Add(this.titleGroup);
            this.Controls.Add(this.GameOverBanner);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.helthBarLabel);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtAmmo);
            this.Name = "Game";
            this.Text = "Zombie-Shooter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.GameOverBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.titleGroup.ResumeLayout(false);
            this.titleGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label helthBarLabel;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox GameOverBanner;
        private System.Windows.Forms.GroupBox titleGroup;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label pressEnterLabel;
        private System.Windows.Forms.Label arrowsToMove;
        private System.Windows.Forms.Label spaceToShoot;
        private System.Windows.Forms.PictureBox titlePic;
    }
}

