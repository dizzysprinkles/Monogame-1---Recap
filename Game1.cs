using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;  //Imports list class...

namespace Monogame_1___Recap
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator;

        Texture2D backgroundTexture, shipTexture, secondShipTexture, thirdShipTexture, fourthShipTexture, fifthShipTexture;
        Rectangle window, shipRect, secondShipRect; /* thirdShipRect, fourthShipRect, fifthShipRect*/
        SpriteFont titleFont;

        List<Texture2D> shipTextures; 
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0,0,800,500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges(); // If this is not run, window doesn't change size

            this.Window.Title = "Content, Scaling, and Texts";

            generator = new Random();

            shipRect = new Rectangle(generator.Next(0,window.Width - 75), generator.Next(0,window.Height-100), 75, 100);
            secondShipRect = new Rectangle(generator.Next(0, window.Width - 75), generator.Next(0, window.Height - 100), 75, 100);

            shipTextures = new List<Texture2D>();
            //thirdShipRect = new Rectangle(310, 300, 75, 100);
            //fourthShipRect = new Rectangle(410, 300, 75, 100);
            //fifthShipRect = new Rectangle(510, 300, 75, 100);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundTexture = Content.Load<Texture2D>("Images/space_background");
           

            for (int i = 1; i <= 5; i++)
            {
                shipTextures.Add(Content.Load<Texture2D>("Images/enterprise_" + i));
            }

            shipTexture = shipTextures[generator.Next(shipTextures.Count)];
            secondShipTexture = shipTextures[generator.Next(shipTextures.Count)];
            //thirdShipTexture = Content.Load<Texture2D>("Images/enterprise_3");
            //fourthShipTexture = Content.Load<Texture2D>("Images/enterprise_4");
            //fifthShipTexture = Content.Load<Texture2D>("Images/enterprise_5");

            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);
            _spriteBatch.DrawString(titleFont, "Space Exploration", new Vector2(110, 10), Color.YellowGreen);
            _spriteBatch.Draw(secondShipTexture, secondShipRect, Color.White);
            _spriteBatch.Draw(shipTexture, shipRect, null, Color.White * 0.2f, 1f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);


            //_spriteBatch.Draw(thirdShipTexture, thirdShipRect, Color.White);
            //_spriteBatch.Draw(fourthShipTexture, fourthShipRect, Color.White);
            //_spriteBatch.Draw(fifthShipTexture, fifthShipRect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
