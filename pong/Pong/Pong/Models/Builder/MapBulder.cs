using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Models.Builder
{
    public static class MapBulder
    {
        public  static List<Block> GetBlocks(GraphicsDevice graphicsDevice) 
        {
            List<Block> blocks = new List<Block>();
            for (int i = 0; i < Game1.ScreenWidth; i += 120)
            {
                int y = i % 2 == 0 ? 50 : 200;
                blocks.Add(GetBlock(graphicsDevice, i, y));
            }
            return blocks;
        }
        
        public static Block GetBlock(GraphicsDevice graphicsDevice, int x, int y)
        {
            var b = new Block(new Texture2D(graphicsDevice, 200, 30, false, SurfaceFormat.Single));
            b.Position.X = x;
            b.Position.Y = y;
            return b;
        }
    }
}
