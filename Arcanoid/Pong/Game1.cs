using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using Pong.Models.Loaders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pong
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;

        List<Block> Blocks;
        Ball Ball;
        Player Player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Blocks = new List<Block>();
        }

        protected override void Initialize()
        {
            Player = new Player();
            Ball = new Ball(4f);
            Blocks = BlockLoader.CreateBlocks(24, 6, 40);

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Player.LoadTexture(new Texture2D(GraphicsDevice, 100, 20, false, SurfaceFormat.Single));
            Ball.LoadTexture(new Texture2D(GraphicsDevice, 10, 10, false, SurfaceFormat.Single));

            Blocks.ForEach(b => b.LoadTexture(new Texture2D(GraphicsDevice, 200, 20, false, SurfaceFormat.Single)));
            Blocks.ForEach(b => Ball.AddSprite(b));
            Ball.AddSprite(Player);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Player.Control(Keyboard.GetState());
            Player.Update();
            Ball.Update(gameTime);
            
            foreach (var b in Blocks)
            {
                if (b.IsEnabled)
                {
                    b.Update(gameTime);
                }
            }

            if(Ball.Position.Y + Ball.Rectangle.Height >= 480)
            {
                OnGameEnd();
            }
            base.Update(gameTime);
        }

        private void OnGameEnd()
        {
            Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Player.Draw(spriteBatch);
            Ball.Draw(spriteBatch);
            foreach (var b in Blocks)
            {
                b.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
