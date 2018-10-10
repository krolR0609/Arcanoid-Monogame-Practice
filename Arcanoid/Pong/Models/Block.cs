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
        public Block(int x, int y, int width, int height) : this()
        {
            _rectangle = new Rectangle(x, y, width, height);
        }
        public Block(int x, int y) : this()
        {
            Position = new Vector2(x, y);
        }
        public Block() : base()
        {
            HitCount = 0;
            Position = new Vector2(400, 400);

            _rectangle = new Rectangle((int)Position.X, (int)Position.Y, 32, 32);

            this.OnCollision += OnTriggered;
        }

        private Rectangle _rectangle;

        public int HitCount;

        public virtual Rectangle DrawRect
        {
            get
            {
                return new Rectangle(0, 0, 64, 64);
            }
        }
        public override Rectangle Rectangle
        {
            get
            {
                return _rectangle;
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
        public override void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsEnabled)
            {
                spriteBatch.Draw(texture, Rectangle, DrawRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 1);
            }
        }
    }
}
