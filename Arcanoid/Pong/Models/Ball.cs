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
        public Ball(float ballSpeed = 12f) : base()
        {
            this.ballSpeed = ballSpeed;
            this._spritesCollisions = new List<Sprite>();
            Init();
        }

        private float ballSpeed;
        private List<Sprite> _spritesCollisions;

        public bool IsPlaying = true;

        public override void Update(GameTime gameTime)
        {
            if (!IsPlaying)
            {
                return;
            }
            CheckSpriteColissions();
            CheckScreenColissions(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);

            this.Position += this.Velocity * this.ballSpeed;
        }

        public void AddSprite(Sprite sprite)
        {
            _spritesCollisions.Add(sprite);
        }
        public void Control(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Space))
            {
                IsPlaying = !IsPlaying;
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
            this.Position = new Vector2(300, 350 ); //start postion
            this.Velocity = new Vector2(1, 1); //start angle
        }
        private void CheckSpriteColissions()
        {
            foreach (var sprite in _spritesCollisions)
            {
                if (sprite == this || !sprite.IsEnabled)
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
            if (Position.Y < y0 || Position.Y + texture.Height >= y1)
            {
                Velocity.Y = -Velocity.Y;
            }
            if (Position.X < x0)
            {
                Velocity.X = -Velocity.X;
            }
        }
    }
}
