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
    public class Player : Sprite
    {
        private float speed = 10f;
        private float velocity = 1.2f;
        public Player(Texture2D texture2D) : base(texture2D)
        {
            this.Position.Y = 400;
            this.Position.X = Game1.ScreenWidth / 2;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Position.X < 0)
            {
                return;
            }
            if (this.Position.X > Game1.ScreenWidth)
            {
                return;
            }
        }
        public void Control(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                this.Position.X += speed * velocity;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                this.Position.X -= speed * velocity;
            }
        }
    }
}
