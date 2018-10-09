using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models.Loaders
{
    public class BlockLoader
    {
        public static List<Block> CreateBlocks(int count, int diff, int width = 32, int height = 32)
        {
            List<Block> blocks = new List<Block>();
            for(int i = 1; i <= count; i++)
            {
                int y = 0;
                switch(i % 2)
                {
                    case 0: y = 100;
                        break;
                    case 1: y = 150;
                        break;
                    case 2: y = 200;
                        break;
                    default: y = 250;
                        break;
                }
                blocks.Add(new Block(i * diff, y, width, height));
            }
            return blocks;
        }
    }
}
