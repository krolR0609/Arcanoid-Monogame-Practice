﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Models
{
    public class Player : Sprite
    {
        private float _speed = 10f;
        private float _velocity = 1.2f;
        private SpriteFont _font;

        private string _DEBUG_STRING
        {
            get
            {
                return $"x:{this.Position.X}, y:{this.Position.Y} \n";
            }
        }

        public Player(Texture2D texture2D, SpriteFont font = null) : base(texture2D)
        {
            this.Position.Y = 400;
            this.Position.X = Game1.ScreenWidth / 2;
            this._font = font;
        }

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
#if DEBUG
            if (_font != null)
            {
                spriteBatch.DrawString(_font, _DEBUG_STRING, new Vector2(10, 10), Color.Red);
            }
#endif
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
