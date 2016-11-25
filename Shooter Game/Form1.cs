#define My_Debug
using Shooter_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter_Game
{
    public partial class ShooterGame : Form
    {
        const int frameNum = 8;
        const int splatNum = 3;
        bool splat = false;
        int _gameFrame = 0;
        int _splatTime = 0;

        int _hits = 0;
        int _misses = 0;
        int _totalShots = 0;
        double _averageHits = 0;

#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        CDuck _duck;
        CSign _sign;
        CSplat _splat;
        CScoreFrame _scoreFrame;
        Random rnd = new Random();

        public ShooterGame()
        {
            InitializeComponent();

            Bitmap b = new Bitmap(Resources.Site);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);

            _scoreFrame = new CScoreFrame() { Left = 10, Top = -60 };
            _sign = new CSign() { Left = 460, Top = 50 };
            _duck = new CDuck() { Left = 70, Top = 180 };
            _splat = new CSplat();
        }

        private void timeGame_Tick(object sender, EventArgs e)
        {
            if (_gameFrame >= frameNum)
            {
                UpdateDuck();
                _gameFrame = 0;
            }

            if (splat)
            {
                if(_splatTime >= splatNum)
                {
                    splat = false;
                    _splatTime = 0;
                    UpdateDuck();
                }
                _splatTime++;
            }
            _gameFrame++;
            this.Refresh();
        }

        private void UpdateDuck()
        {
            _duck.Update(
                rnd.Next(Resources.duck.Width, this.Width - Resources.duck.Width),
                rnd.Next(this.Height / 3, this.Height - Resources.duck.Height)
                );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            if (splat == true)
            {
                _splat.DrawImage(dc);
            }
            else
            {
                _duck.DrawImage(dc);
            }
            
            _sign.DrawImage(dc);
            _scoreFrame.DrawImage(dc);

#if My_Debug
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font, new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flags);
#endif

            TextFormatFlags flags1 = TextFormatFlags.Left;
            Font _font1 = new System.Drawing.Font("Stencil", 12, FontStyle.Bold);
            TextRenderer.DrawText(e.Graphics, "Shots: " + _totalShots.ToString(), _font1, new Rectangle(35, 35, 120, 20), SystemColors.ControlText, flags1);
            TextRenderer.DrawText(e.Graphics, "Hits: " + _hits.ToString(), _font1, new Rectangle(165, 35, 120, 20), SystemColors.ControlText, flags1);
            TextRenderer.DrawText(e.Graphics, "Misses: " + _misses.ToString(), _font1, new Rectangle(35, 60, 120, 20), SystemColors.ControlText, flags1);
            TextRenderer.DrawText(e.Graphics, "Average: " + _averageHits.ToString("F0") + "%", _font1, new Rectangle(150, 60, 120, 20), SystemColors.ControlText, flags1);



            base.OnPaint(e);
        }

        private void ShooterGame_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;
            _cursY = e.Y;
#endif
            this.Refresh(); 
        }

        private void ShooterGame_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.X > 508 && e.X < 600 && e.Y > 64 && e.Y < 83)
            {
                timeGame.Start();
            }
            else if(e.X > 508 && e.X < 600 && e.Y > 83 && e.Y < 112)
            {
                timeGame.Stop();
            }
            else if (e.X > 508 && e.X < 600 && e.Y > 112 && e.Y < 136)
            {
                //timeGame.Stop();
                _hits = 0;
                _misses = 0;
                _averageHits = 0;
                _totalShots = 0;
                this.Refresh();
            }
            else if (e.X > 508 && e.X < 600 && e.Y > 136 && e.Y < 160)
            {
                //timeGame.Stop();
                this.Close();
            }
            else
            {

                if (_duck.Hit(e.X, e.Y))
                {
                    splat = true;
                    _splat.Left = _duck.Left - Resources.Splat.Width / 3;
                    _splat.Top = _duck.Top - Resources.Splat.Height / 3;
                    _hits++;
                }
                else
                {
                    _misses++;
                }

                _totalShots = _hits + _misses;
                _averageHits = (double)_hits / (double)_totalShots * 100.0;

                FireGun();
            }

            

        }

        private void FireGun()
        {
            SoundPlayer simpleSound = new SoundPlayer(Resources.Shotgun);
            simpleSound.Play();
        }
    }
}
