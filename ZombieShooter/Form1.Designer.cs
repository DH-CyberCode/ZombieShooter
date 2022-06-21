namespace ZombieShooter
{
    partial class GameWindow
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
            this.label3 = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOverBanner = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.storeFront = new System.Windows.Forms.PictureBox();
            this.greenCar = new System.Windows.Forms.PictureBox();
            this.blueCar = new System.Windows.Forms.PictureBox();
            this.parkingSpot1 = new System.Windows.Forms.PictureBox();
            this.parkinSpot2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingSpot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkinSpot2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.White;
            this.txtAmmo.Location = new System.Drawing.Point(144, 16);
            this.txtAmmo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(114, 29);
            this.txtAmmo.TabIndex = 0;
            this.txtAmmo.Text = "Ammo: 0";
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(1021, 16);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(110, 29);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Score: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(452, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Health";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(555, 15);
            this.healthBar.Margin = new System.Windows.Forms.Padding(4);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(305, 28);
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
            this.GameOverBanner.BackColor = System.Drawing.Color.Transparent;
            this.GameOverBanner.Image = global::ZombieShooter.Properties.Resources.GameOver;
            this.GameOverBanner.Location = new System.Drawing.Point(419, 204);
            this.GameOverBanner.Margin = new System.Windows.Forms.Padding(4);
            this.GameOverBanner.Name = "GameOverBanner";
            this.GameOverBanner.Size = new System.Drawing.Size(356, 245);
            this.GameOverBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GameOverBanner.TabIndex = 5;
            this.GameOverBanner.TabStop = false;
            this.GameOverBanner.Visible = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::ZombieShooter.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(609, 770);
            this.player.Margin = new System.Windows.Forms.Padding(4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // storeFront
            // 
            this.storeFront.Image = global::ZombieShooter.Properties.Resources.store_front;
            this.storeFront.Location = new System.Drawing.Point(117, 50);
            this.storeFront.Margin = new System.Windows.Forms.Padding(4);
            this.storeFront.Name = "storeFront";
            this.storeFront.Size = new System.Drawing.Size(799, 119);
            this.storeFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.storeFront.TabIndex = 6;
            this.storeFront.TabStop = false;
            // 
            // greenCar
            // 
            this.greenCar.BackColor = System.Drawing.Color.Transparent;
            this.greenCar.Image = global::ZombieShooter.Properties.Resources.GreenCar;
            this.greenCar.Location = new System.Drawing.Point(220, 204);
            this.greenCar.Margin = new System.Windows.Forms.Padding(4);
            this.greenCar.Name = "greenCar";
            this.greenCar.Size = new System.Drawing.Size(71, 142);
            this.greenCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.greenCar.TabIndex = 7;
            this.greenCar.TabStop = false;
            this.greenCar.Tag = "car";
            // 
            // blueCar
            // 
            this.blueCar.BackColor = System.Drawing.Color.Transparent;
            this.blueCar.Image = global::ZombieShooter.Properties.Resources.BluieCar;
            this.blueCar.Location = new System.Drawing.Point(985, 204);
            this.blueCar.Margin = new System.Windows.Forms.Padding(4);
            this.blueCar.Name = "blueCar";
            this.blueCar.Size = new System.Drawing.Size(71, 142);
            this.blueCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.blueCar.TabIndex = 8;
            this.blueCar.TabStop = false;
            this.blueCar.Tag = "car";
            // 
            // parkingSpot1
            // 
            this.parkingSpot1.BackColor = System.Drawing.Color.Transparent;
            this.parkingSpot1.Image = global::ZombieShooter.Properties.Resources.ParkingSpot;
            this.parkingSpot1.Location = new System.Drawing.Point(117, 204);
            this.parkingSpot1.Margin = new System.Windows.Forms.Padding(4);
            this.parkingSpot1.Name = "parkingSpot1";
            this.parkingSpot1.Size = new System.Drawing.Size(71, 142);
            this.parkingSpot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.parkingSpot1.TabIndex = 9;
            this.parkingSpot1.TabStop = false;
            this.parkingSpot1.Tag = "emptyspot";
            // 
            // parkinSpot2
            // 
            this.parkinSpot2.BackColor = System.Drawing.Color.Transparent;
            this.parkinSpot2.Image = global::ZombieShooter.Properties.Resources.ParkingSpot;
            this.parkinSpot2.Location = new System.Drawing.Point(1088, 204);
            this.parkinSpot2.Margin = new System.Windows.Forms.Padding(4);
            this.parkinSpot2.Name = "parkinSpot2";
            this.parkinSpot2.Size = new System.Drawing.Size(71, 142);
            this.parkinSpot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.parkinSpot2.TabIndex = 10;
            this.parkinSpot2.TabStop = false;
            this.parkinSpot2.Tag = "emptyspot";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1312, 937);
            this.Controls.Add(this.GameOverBanner);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtAmmo);
            this.Controls.Add(this.storeFront);
            this.Controls.Add(this.blueCar);
            this.Controls.Add(this.parkinSpot2);
            this.Controls.Add(this.greenCar);
            this.Controls.Add(this.parkingSpot1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameWindow";
            this.Text = "Zombie-Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.GameOverBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingSpot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkinSpot2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox GameOverBanner;
        private System.Windows.Forms.PictureBox storeFront;
        private System.Windows.Forms.PictureBox greenCar;
        private System.Windows.Forms.PictureBox blueCar;
        private System.Windows.Forms.PictureBox parkingSpot1;
        private System.Windows.Forms.PictureBox parkinSpot2;
    }
}

