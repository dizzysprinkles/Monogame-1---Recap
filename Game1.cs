using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_1___Recap
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D backgroundTexture, shipTexture, secondShipTexture, thirdShipTexture, fourthShipTexture, fifthShipTexture;
        Rectangle window, shipRect, secondShipRect, thirdShipRect, fourthShipRect, fifthShipRect;
        SpriteFont titleFont;
        

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

            shipRect = new Rectangle(110, 300, 75, 100);
            secondShipRect = new Rectangle(210, 300, 75, 100);
            thirdShipRect = new Rectangle(310, 300, 75, 100);
            fourthShipRect = new Rectangle(410, 300, 75, 100);
            fifthShipRect = new Rectangle(510, 300, 75, 100);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundTexture = Content.Load<Texture2D>("Images/space_background");
            shipTexture = Content.Load<Texture2D>("Images/enterprise_1");
            secondShipTexture = Content.Load<Texture2D>("Images/enterprise_2");
            thirdShipTexture = Content.Load<Texture2D>("Images/enterprise_3");
            fourthShipTexture = Content.Load<Texture2D>("Images/enterprise_4");
            fifthShipTexture = Content.Load<Texture2D>("Images/enterprise_5");

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
            _spriteBatch.DrawString(titleFont, "Space Exploration", new Vector2(150, 10), Color.YellowGreen);
            _spriteBatch.Draw(secondShipTexture, secondShipRect, Color.White);
            _spriteBatch.Draw(shipTexture, shipRect, Color.White);
            _spriteBatch.Draw(thirdShipTexture, thirdShipRect, Color.White);
            _spriteBatch.Draw(fourthShipTexture, fourthShipRect, Color.White);
            _spriteBatch.Draw(fifthShipTexture, fifthShipRect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
