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
   
    public class Ball : Sprite
    {
        private float ballSpeed;
        public List<Sprite> sprites;

        public bool isPlaying = true;

        public Ball(Texture2D texture, float ballSpeed = 10f):base(texture)
        {
            this.ballSpeed = ballSpeed;
            this.sprites = new List<Sprite>();
            Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (!isPlaying)
            {
                return;
            }

            foreach (var sprite in sprites)
            {
                if (sprite == this || !sprite.Visible)
                    continue;

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                    sprite.OnCollision?.Invoke(this, sprite);
                }
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                    sprite.OnCollision?.Invoke(this, sprite);
                }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                    sprite.OnCollision?.Invoke(this, sprite);
                }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                    sprite.OnCollision?.Invoke(this, sprite);
                }
            }
            #region screenColissions

            if (Position.X >= Game1.ScreenWidth)
            {
                Velocity.X = -Velocity.X;
            }
            if (Position.Y >= Game1.ScreenHeight)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.Y < 0 || Position.Y + _texture.Height >= Game1.ScreenHeight)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.X < 0)
            {
                Velocity.X = -Velocity.X;
            }
            #endregion

            this.Position += this.Velocity * this.ballSpeed;
        }


        public void Control(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Space))
            {
                isPlaying = !isPlaying;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                this.Velocity = new Vector2(1, -1);
            }
            if (state.IsKeyDown(Keys.Down))
            {
                this.Velocity = new Vector2(1, 1);
            }
            if (state.IsKeyDown(Keys.Left))
            {
                this.Velocity = new Vector2(1, 1);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                this.Velocity = new Vector2(-1, 1);
            }
        }
        public void Pause()
        {

        }
        private void Init()
        {
            this.Position = new Vector2(0, 0); //start postion
            this.Velocity = new Vector2(1, 1); //start angle
        }
        public void Restart()
        {
            
        }
    }
}
