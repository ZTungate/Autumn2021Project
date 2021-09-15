using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        public ISprite sprite;

        private SpriteFont font;

        public List<IController> controllerList;

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            sprite = new NonAnimatedStillSprite(this);

            controllerList = new List<IController>()
            {
                new KeyboardController(this),
                new MouseController(this),
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Credits");

            // TODO: use this.Content to load your game content here
            sprite.Texture = Content.Load<Texture2D>("ball");

        }

        protected override void Update(GameTime gameTime)
        {



            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }

            sprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
       
            _spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRect[sprite.CurrentFrame], Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            
            _spriteBatch.DrawString(font, "Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/", new Vector2(_graphics.PreferredBackBufferWidth / 2 - font.MeasureString("Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/").X / 2, _graphics.PreferredBackBufferHeight / 2 - font.MeasureString("Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/").Y / 2 + 100), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void quit()
        {
            Exit();
        }
    }
}
