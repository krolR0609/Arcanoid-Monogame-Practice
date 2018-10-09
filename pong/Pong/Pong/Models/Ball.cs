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
        private List<Sprite> _spritesCollisions;

        public bool isPlaying = true;

        public Ball(Texture2D texture, float ballSpeed = 10f) : base(texture)
        {
            this.ballSpeed = ballSpeed;
            this._spritesCollisions = new List<Sprite>();
            Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (!isPlaying)
            {
                return;
            }

            CheckSpriteColissions();
            CheckScreenColissions(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);

            this.Position += this.Velocity * this.ballSpeed;
        }

        private void CheckSpriteColissions()
        {
            foreach (var sprite in _spritesCollisions)
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
        }

        private void CheckScreenColissions(int x0, int y0, int x1, int y1)
        {
            if (Position.X >= x1)
            {
                Velocity.X = -Velocity.X;
            }
            if (Position.Y >= y1)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.Y < y0 || Position.Y + _texture.Height >= y1)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.X < x0)
            {
                Velocity.X = -Velocity.X;
            }
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

        private void Init()
        {
            this.Position = new Vector2(0, 0); //start postion
            this.Velocity = new Vector2(1, 1); //start angle
        }

    }
}
