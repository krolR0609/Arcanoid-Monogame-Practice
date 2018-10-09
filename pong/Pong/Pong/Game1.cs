using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using Pong.Models.Builder;
using System.Collections.Generic;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;


        Ball ball;
        List<Block> blocks = new List<Block>();
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player(new Texture2D(GraphicsDevice, 250, 100, false, SurfaceFormat.Single));
            // TODO: Add your initialization logic here
            ball = new Ball(new Texture2D(GraphicsDevice, 10, 10, false, SurfaceFormat.Single));

            var bText = new Texture2D(GraphicsDevice, 200, 50, false, SurfaceFormat.Single);
            var blok1 = new Block(bText);
            blok1.Position.X = 100;
            blok1.Position.Y = 100;

            var blok2 = new Block(bText);
            blok2.Position.X = 500;
            blok2.Position.Y = 50;

            blocks.Add(blok1);
            blocks.Add(blok2);

            ball._spritesCollisions.Add(blok1);
            ball._spritesCollisions.Add(blok2);
            ball._spritesCollisions.Add(player);

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Control(Keyboard.GetState());
            player.Update(gameTime);

            //ball.Control(Keyboard.GetState());
            ball.Update(gameTime);

            foreach(var b in blocks)
            {
                b.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            foreach (var b in blocks)
            {
                b.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
