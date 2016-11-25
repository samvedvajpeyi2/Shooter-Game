namespace Shooter_Game
{
    partial class ShooterGame
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
            this.timeGame = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timeGame
            // 
            this.timeGame.Tick += new System.EventHandler(this.timeGame_Tick);
            // 
            // ShooterGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Shooter_Game.Properties.Resources.bgfarm;
            this.ClientSize = new System.Drawing.Size(615, 332);
            this.Name = "ShooterGame";
            this.Text = "Shooter Game";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShooterGame_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShooterGame_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timeGame;
    }
}

