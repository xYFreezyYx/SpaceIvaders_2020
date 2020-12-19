namespace SpaceInvaders2020
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
            this.Life = new System.Windows.Forms.Label();
            this.LifeCounterLable = new System.Windows.Forms.Label();
            this.Kills = new System.Windows.Forms.Label();
            this.KillCounterLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Life
            // 
            this.Life.AutoSize = true;
            this.Life.Font = new System.Drawing.Font("Papyrus", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Life.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Life.Location = new System.Drawing.Point(1045, 19);
            this.Life.Name = "Life";
            this.Life.Size = new System.Drawing.Size(90, 54);
            this.Life.TabIndex = 0;
            this.Life.Text = "Life";
            this.Life.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LifeCounterLable
            // 
            this.LifeCounterLable.AutoSize = true;
            this.LifeCounterLable.Font = new System.Drawing.Font("Papyrus", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LifeCounterLable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LifeCounterLable.Location = new System.Drawing.Point(1064, 73);
            this.LifeCounterLable.Name = "LifeCounterLable";
            this.LifeCounterLable.Size = new System.Drawing.Size(48, 60);
            this.LifeCounterLable.TabIndex = 1;
            this.LifeCounterLable.Text = "3";
            this.LifeCounterLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Kills
            // 
            this.Kills.AutoSize = true;
            this.Kills.Font = new System.Drawing.Font("Papyrus", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kills.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Kills.Location = new System.Drawing.Point(1042, 133);
            this.Kills.Name = "Kills";
            this.Kills.Size = new System.Drawing.Size(93, 54);
            this.Kills.TabIndex = 2;
            this.Kills.Text = "Kills";
            this.Kills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KillCounterLable
            // 
            this.KillCounterLable.AutoSize = true;
            this.KillCounterLable.Font = new System.Drawing.Font("Papyrus", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KillCounterLable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.KillCounterLable.Location = new System.Drawing.Point(1064, 187);
            this.KillCounterLable.Name = "KillCounterLable";
            this.KillCounterLable.Size = new System.Drawing.Size(48, 60);
            this.KillCounterLable.TabIndex = 3;
            this.KillCounterLable.Text = "0";
            this.KillCounterLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1162, 593);
            this.Controls.Add(this.KillCounterLable);
            this.Controls.Add(this.Kills);
            this.Controls.Add(this.LifeCounterLable);
            this.Controls.Add(this.Life);
            this.Name = "Game";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Life;
        private System.Windows.Forms.Label LifeCounterLable;
        private System.Windows.Forms.Label Kills;
        private System.Windows.Forms.Label KillCounterLable;
    }
}

