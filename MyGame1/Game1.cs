using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace MyGame1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D   ball;
        Texture2D   ovni;

        Vector2 resolutionFactor;

        Rectangle _screenBounds; 
        Matrix _screenXform;

        Sprites player;
        Sprites enemy;

        TouchCollection touchState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            Content.RootDirectory = "Content";

            Window.ClientSizeChanged += Window_ClientSizeChanged;

            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;

            graphics.ApplyChanges();

            var screenScale = Window.ClientBounds.Width / 1080.0f;

            resolutionFactor = new Vector2(
                graphics.PreferredBackBufferWidth / Window.ClientBounds.Width / screenScale,
                graphics.PreferredBackBufferHeight / Window.ClientBounds.Height / screenScale);

            _screenBounds = new Rectangle(0, 0,
                (int)(graphics.PreferredBackBufferWidth * screenScale),
                (int)(graphics.PreferredBackBufferHeight * screenScale));

            _screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);

        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;

            graphics.ApplyChanges();

            var screenScale = Window.ClientBounds.Width / 1080.0f;

            resolutionFactor = new Vector2(
                graphics.PreferredBackBufferWidth / Window.ClientBounds.Width / screenScale,
                graphics.PreferredBackBufferHeight / Window.ClientBounds.Height / screenScale);

            _screenBounds = new Rectangle(0, 0,
                (int)(graphics.PreferredBackBufferWidth * screenScale),
                (int)(graphics.PreferredBackBufferHeight * screenScale));

            _screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //TouchPanel.DisplayWidth = _screenBounds.Width;
            //TouchPanel.DisplayHeight = _screenBounds.Height;

            
            //GraphicsDevice.Adapter.CurrentDisplayMode.Width;


            //IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball = Content.Load<Texture2D>("Prototype/ball_prototype");
            ovni = Content.Load<Texture2D>("prototype/ovni_prototype");

            player = new Sprites(spriteBatch, ball);
            player.Position = new Vector2(Window.ClientBounds.Center.X * resolutionFactor.X - player.Size.Center.X, 0);

            enemy = new Sprites(spriteBatch, ovni);
            enemy.Position = Vector2.Zero;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            touchState = TouchPanel.GetState();

            foreach (var s in touchState)
            {
                if (s.State == TouchLocationState.Pressed || s.State == TouchLocationState.Moved)
                {
                    player.Position.X = s.Position.X * resolutionFactor.X - player.Size.Center.X;
                    player.Position.Y = s.Position.Y * resolutionFactor.Y - player.Size.Center.Y;
                }
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

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _screenXform);

            enemy.Draw();
            player.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
