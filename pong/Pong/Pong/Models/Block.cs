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
    public class Block : Ball
    {
        public int HitCount;

        public Block(Texture2D texture2D) : base(texture2D)
        {
            HitCount = 0;
            Position = new Vector2(400, 400);

            this.OnCollision += OnTriggered;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void OnTriggered(object obj, Sprite sprite)
        {
            Visible = false;
            HitCount++;
        }
        public override void Update(GameTime gameTime)
        {
        }
    }
}
