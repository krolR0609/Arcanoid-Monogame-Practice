﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using System.Collections.Generic;

namespace Pong
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public SpriteFont DebugFont;

        public List<Sprite> Sprites = new List<Sprite>();

        Ball ball;
        List<Block> blocks = new List<Block>();
        Player player;

        private Texture2D blockTexture;

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
            player = new Player(new Texture2D(GraphicsDevice, 200, 20, false, SurfaceFormat.Single));
            // TODO: Add your initialization logic here
            ball = new Ball(new Texture2D(GraphicsDevice, 10, 10, false, SurfaceFormat.Single));

            var bText = new Texture2D(GraphicsDevice, 200, 50, false, SurfaceFormat.Single);
            blockTexture = Content.Load<Texture2D>("SpaceBlock");
            bText = blockTexture; 

            var blok1 = new Block(bText);

            blok1.Position.X = 100;
            blok1.Position.Y = 100;

            var blok2 = new Block(bText);
            blok2.Position.X = 500;
            blok2.Position.Y = 50;

            blocks.Add(blok1);
            blocks.Add(blok2);

            ball.AddSprite(blok1);
            ball.AddSprite(blok2);
            ball.AddSprite(player);

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            Sprites.Add(player);
            Sprites.Add(ball);
            Sprites.Add(blok1);
            Sprites.Add(blok2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            DebugFont = Content.Load<SpriteFont>("DebugFont");
            
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
#if DEBUG
            for (int i = 0; i < Sprites.Count; i++)
            {
                spriteBatch.DrawString(DebugFont, Sprites[i].DebugString, new Vector2(10, 15 * (i + 1)), Color.Red);
            }
#endif
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
