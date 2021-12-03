using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LevelCreator.Sprites.Factories;
using System.Collections.Generic;
using LevelCreator.UI;

namespace LevelCreator
{
    public class LevelCreator : Game
    {
        public static LevelCreator instace;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Level currentLevel;
        private LevelCreatorUIHandler uiHandler;

        public LevelCreator()
        {
            instace = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GeneralFactory.instance.LoadAllContent(Content);
            uiHandler = new LevelCreatorUIHandler(new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            currentLevel = new Level("UnnamedLevel");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            uiHandler.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            currentLevel.Draw(spriteBatch);
            uiHandler.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
