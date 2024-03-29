﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Models
{
    public class Player : Sprite
    {
        public Player() : base()
        {
            this.Position.Y = 450;
            this.Position.X = Game1.ScreenWidth / 2;
        }

        private float _speed = 10f;
        private float _velocity = 1.2f;

        public override void Update(GameTime gameTime)
        {
            if (this.Position.X < 0)
            {
                this.Position.X = 0;
            }
            if (this.Position.X + this.texture.Width > Game1.ScreenWidth)
            {
                this.Position.X = Game1.ScreenWidth - this.texture.Width;
            }
        }

        public void Update()
        {
            if (this.Position.X < 0)
            {
                this.Position.X = 0;
            }
            if (this.Position.X + this.texture.Width > Game1.ScreenWidth)
            {
                this.Position.X = Game1.ScreenWidth - this.texture.Width;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Control(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                this.Position.X += _speed * _velocity;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                this.Position.X -= _speed * _velocity;
            }
        }
    }
}
