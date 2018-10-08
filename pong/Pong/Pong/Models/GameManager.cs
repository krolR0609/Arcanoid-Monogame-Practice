using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pong.Models
{
    public class GameManager
    {
        private Ball ball;
        private IList<Block> blocks;

        private SpriteBatch spriteBatch;

        public State gameState;



        public GameManager()
        {
            this.gameState = State.Running;
        }

        public void LoadSpriteBatch(SpriteBatch batch)
        {
            this.spriteBatch = batch;
        }
       

        public void LoadPlayer(Ball player)
        {
            this.ball = player;
        }
        public void LoadBlocks(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void Reset()
        {

        }

        public void Update()
        {
            UpdateLogic();
        }

        private void PauseGame()
        {
            throw new NotImplementedException();
        }

        private void UpdateLogic()
        {
            //ball.Update(blocks.ToList());
            foreach (var block in blocks)
            {
            }
        }

        public void Draw()
        {
            ball.Draw(spriteBatch);
            foreach (var block in blocks)
            {
                block.Draw(spriteBatch);
            }
        }
    }

    public enum State
    {
        Pause = 0,
        Running = 1,
        Exit = 3,
    }
}
