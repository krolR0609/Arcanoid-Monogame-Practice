using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models.Game
{
    public class GameScreen
    {
        public GameScreen(int startX, int startY, int screenWidth, int screenHight)
        {
            this.ScreenStartX = startX;
            this.ScreenStartY = startY;
            this.ScreenWidth = screenWidth;
            this.ScreenHight = screenHight;
        }

        public int ScreenStartX { get; }
        public int ScreenStartY { get; }
        public int ScreenWidth { get; }
        public int ScreenHight { get; }
    }
}
