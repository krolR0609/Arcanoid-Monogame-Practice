using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models.Loaders
{
    public class BlockLoader
    {
        public static List<Block> CreateBlocks(int cols,int rows, int diff, int width = 32, int height = 32)
        {
            List<Block> blocks = new List<Block>();

            for(int x = 1; x <= cols; x++)
            {
                for(int y = 1; y <= rows; y++)
                {
                    blocks.Add(new Block(x * diff, y * diff, width, height));
                }
                
            }
            return blocks;
        }
    }
}
