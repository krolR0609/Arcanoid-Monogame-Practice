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
    public class Block : Sprite
    {
        public int HitCount;

        public override string SpriteName { get => "SpaceBlock"; }
        public Block(Texture2D texture2D) : base(texture2D)
        {
            HitCount = 0;
            Position = new Vector2(400, 400);

            this.OnCollision += OnTriggered;
        }
        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 64, 32);
            }
        }

        public virtual Rectangle DrawRect
        {
            get
            {
                return new Rectangle(0, 0, 64, 64);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsEnabled)
            {
                spriteBatch.Draw(texture, Rectangle, DrawRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 1);
            }
        }
            
        public void OnTriggered(object obj, Sprite sprite)
        {
            IsEnabled = false;
            HitCount++;
        }
        public override void Update(GameTime gameTime)
        {

        }
    }
}
