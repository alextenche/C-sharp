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

        // 2.Declared fields for the mine sprite and the list of mines in the Game1 class.
        Texture2D mineSprite;
        List<Mine> mines;

        // 3.Declared fields to support left click processing in the Game1 class.
        bool leftButtonPressed;

        // 5.Declared fields in the Game1 class to support spawning teddy bears at random times.
        Texture2D teddyBearSprite;
        List<TeddyBear> teddyBears;
        Random rand;

        // 10.Declared fields in the Game1 class for the explosion sprite and the list of explosions
        Texture2D explosionSprite;
        List<Explosion> explosions;
        
        int teddyBearSpawnTime;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // 1.Set the resolution and made the mouse visible in the Game1 constructor.
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            IsMouseVisible = true;

            // 2.list of Mines
            mines = new List<Mine>();

            // Init leftButton of mouse to not pressed
            leftButtonPressed = false;

            // 5.list of teddy bears
            teddyBears = new List<TeddyBear>();

            // 6.Set the first spawn delay between 1 and 3 seconds
            rand = new Random();
            teddyBearSpawnTime = rand.Next(1000, 3001);

            // 10.list of explosions 
            explosions = new List<Explosion>();
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

            // 2.Loaded the mine sprite in the Game1 LoadContent method.
            mineSprite = Content.Load<Texture2D>("mine");

            // 6.Added code to the Game1 LoadContent method to load the teddy bear sprite.
            teddyBearSprite = Content.Load<Texture2D>("teddybear");

            // 11.Added code to the Game1 LoadContent method to load the explosion sprite
            explosionSprite = Content.Load<Texture2D>("explosion");
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

            // 3.Added code to the Game1 Update method to add a mine to the list of mines when a left click is finished.
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                leftButtonPressed = true;
            }

            if (mouse.LeftButton == ButtonState.Released && leftButtonPressed)
            {
                mines.Add(new Mine(mineSprite, mouse.X, mouse.Y));
                leftButtonPressed = false;
            }


            // 7.Added code to the Game1 Update method to update the spawn timer and (when the timer is finished) reset the spawn timer,
            // set a new random spawn delay between 1 and 3 seconds, 
            // spawn a new teddy bear (with a random velocity as described above) and add it to the list of teddy bears
            if (teddyBearSpawnTime <= 0)
            {
                teddyBearSpawnTime = rand.Next(1000, 3001);
                teddyBears.Add(new TeddyBear(teddyBearSprite, new Vector2( (float) (rand.NextDouble() - 0.5), (float) ( rand.NextDouble() - 0.5)), WINDOW_WIDTH, WINDOW_HEIGHT));
            }
            else
            {
                teddyBearSpawnTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            // 9.Added code to the Game1 Update method to tell each of the teddy bears in the list of teddy bears to update itself.
            foreach (TeddyBear singleTeddyBear in teddyBears)
            {
                singleTeddyBear.Update(gameTime);
            }

            // 12.Added code to the Game1 Update method to detect teddy bear collisions with mines and, if a collision is detected,
            // make the teddy bear inactive, make the mine inactive, and add a new explosion to the list of explosions.
            for (int i = 0; i < teddyBears.Count; i++)
            {
                for (int j = 0; j < mines.Count; j++)
                {
                    if (teddyBears[i].CollisionRectangle.Intersects(mines[j].CollisionRectangle))
                    {                      
                        teddyBears[i].Active = false;   
                        mines[j].Active = false;
                        explosions.Add(new Explosion(explosionSprite, teddyBears[i].CollisionRectangle.Center.X, teddyBears[i].CollisionRectangle.Center.Y));
                        break;
                    }
                }
            }

            // 14.Added code to the Game1 Update method to tell each of the explosions in the list of explosions to update itself.
            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }

            // 15.Added code to the Game1 Update method to remove inactive teddy bears, mines, and explosions from their respective lists
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

            spriteBatch.Begin();

            // 4.Added code to the Game1 Draw method to tell each of the mines in the list of mines to draw itself.
            foreach (Mine singleMine in mines)
            {
                singleMine.Draw(spriteBatch);
            }

            // 8.Added code to the Game1 Draw method to tell each of the teddy bears in the list of teddy bears to draw itself.
            foreach (TeddyBear singleTeddyBear in teddyBears)
            {
                singleTeddyBear.Draw(spriteBatch);
            }

            // 13.Added code to the Game1 Draw method to tell each of the explosions in the list of explosions to draw itself.
            foreach (Explosion singleExplosion in explosions)
            {
                singleExplosion.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
