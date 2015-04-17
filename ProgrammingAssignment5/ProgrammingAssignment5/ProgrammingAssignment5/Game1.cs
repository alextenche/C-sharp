using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeddyMineExplosion;

namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // game sprites
        Texture2D mineSprite;
        Texture2D teddyBearSprite;
        Texture2D explosionSprite;
        
        // game objects
        List<Mine> mines = new List<Mine>();
        List<TeddyBear> teddyBears = new List<TeddyBear>();
        List<Explosion> explosions = new List<Explosion>();
        
        // click processing
        bool leftClickStarted = false;
        bool leftButtonReleased = true;

        // random spawning support
        int totalSpawnDelayMilliseconds;
        int elapsedSpawnDelayMilliseconds;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set the resolution and made the mouse visible
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
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

            // load teddyBear, mine and explosion sprites
            mineSprite = Content.Load<Texture2D>("mine");
            teddyBearSprite = Content.Load<Texture2D>("teddybear");
            explosionSprite = Content.Load<Texture2D>("explosion");

            // set first spawn delay between 1 and 3 seconds
            totalSpawnDelayMilliseconds = rand.Next(1000,3001);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // get current mouse state
            MouseState mouse = Mouse.GetState();

            // check for left click started
            if (mouse.LeftButton == ButtonState.Pressed && leftButtonReleased)
            {
                leftClickStarted = true;
                leftButtonReleased = false;
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                leftButtonReleased = true;
                // if left click finished, add new mine to the list
                if (leftClickStarted) {
                    leftClickStarted = false;
                    mines.Add(new Mine(mineSprite, mouse.X, mouse.Y));
                }
            }

 
            // spawn a new teddy bear (with a random velocity as described above) and add it to the list of teddy bears
            elapsedSpawnDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedSpawnDelayMilliseconds > totalSpawnDelayMilliseconds)
            {
                elapsedSpawnDelayMilliseconds = 0;
                totalSpawnDelayMilliseconds = rand.Next(1000, 3001);
                teddyBears.Add(new TeddyBear(teddyBearSprite,
                    new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f),
                    WINDOW_WIDTH, WINDOW_HEIGHT));
            }

            
            // check for teddy bear collisions with mines
            foreach (TeddyBear teddyBear in teddyBears)
            {
                foreach (Mine mine in mines)
                {
                    if (teddyBear.Active && mine.Active && teddyBear.CollisionRectangle.Intersects(mine.CollisionRectangle))
                    {
                        explosions.Add(new Explosion(explosionSprite, mine.CollisionRectangle.Center.X, mine.CollisionRectangle.Center.Y));
                        teddyBear.Active = false;   
                        mine.Active = false;
                        
                        break;
                    }
                }
            }

      
            // update game objects
            foreach (TeddyBear teddyBear in teddyBears)
            {
                teddyBear.Update(gameTime);
            }

            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }


            // clean out inactive objects
            for (int i = 0; i < teddyBears.Count; i++)
            {
                if (!teddyBears[i].Active) { teddyBears.RemoveAt(i); }
            }

            for (int i = 0; i < mines.Count; i++)
            {
                if (!mines[i].Active) { mines.RemoveAt(i); }
            }

            for (int i = 0; i < explosions.Count; i++)
            {
                if (!explosions[i].Playing) { explosions.RemoveAt(i); }
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

            // draw game objects
            spriteBatch.Begin();

            foreach (Mine mine in mines)
            {
                mine.Draw(spriteBatch);
            }

            foreach (TeddyBear teddyBear in teddyBears)
            {
                teddyBear.Draw(spriteBatch);
            }

            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
