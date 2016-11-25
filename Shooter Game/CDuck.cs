using Shooter_Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter_Game
{
    class CDuck : CImageBase
    {
        private Rectangle _duckHotSpot = new Rectangle();

        public CDuck()
            : base(Resources.duck)
        {
            _duckHotSpot.X = Left + 20;
            _duckHotSpot.Y = Top - 1;
            _duckHotSpot.Width = 70;
            _duckHotSpot.Height = 70;
        }


        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
            _duckHotSpot.X = Left + 20;
            _duckHotSpot.Y = Top - 1;
        }

        public bool Hit(int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);

            if (_duckHotSpot.Contains(c))
            {
                return true;
            }

            return false;
        }
    }
}
