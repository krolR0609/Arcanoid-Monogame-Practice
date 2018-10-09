using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;

namespace Pong.App_Data
{
    public class GameManager
    {
        private List<Sprite> _screenSprites;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;


        private GameManager(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager contentManager)
        {
            this._graphics = graphics;
            this._spriteBatch = spriteBatch;
            this._content = contentManager;
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {

        }
    }
}
