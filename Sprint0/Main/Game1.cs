using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Enemies;
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
        
        //Sprite factory for enemies
        public EnemySpriteFactory enemySpriteFactory;

        //Enemies
        public Skeleton skeleton;
        public Slime slime;
        public Bat bat;

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

            //Initialize an enemy sprite 
            enemySpriteFactory = EnemySpriteFactory.Instance;

            controllerList = new List<IController>()
            {
                new KeyboardController(this),
                new MouseController(this),
            };

            //Initialize enemies (testing only, this will be handled elsewhere later)
            skeleton = new Skeleton();
            slime = new Slime();
            bat = new Bat();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Credits");

            // TODO: use this.Content to load your game content here
            //Load all textures from the enemy sprite factory.
            enemySpriteFactory.LoadAllTextures(Content);

            skeleton.mySprite = enemySpriteFactory.CreateSkeletonSprite();
            slime.mySprite = enemySpriteFactory.CreateSlimeSprite();
            bat.mySprite = enemySpriteFactory.CreateBatSprite();


            sprite.Texture = Content.Load<Texture2D>("ball");

        }

        protected override void Update(GameTime gameTime)
        {



            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }

            sprite.Update(gameTime);

            //Test
            skeleton.state.Update(gameTime);
            slime.state.Update(gameTime);
            bat.state.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //Using front to back sorting, and point clamp to improve look of pixel art sprites
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);
       
            _spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRect[sprite.CurrentFrame], Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            
            _spriteBatch.DrawString(font, "Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/", new Vector2(_graphics.PreferredBackBufferWidth / 2 - font.MeasureString("Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/").X / 2, _graphics.PreferredBackBufferHeight / 2 - font.MeasureString("Credits\nProgram Made By: Wesley Nguyen\nSprites from: https://www.spriters-resource.com/").Y / 2 + 100), Color.Black);

            skeleton.state.Draw(_spriteBatch);
            slime.state.Draw(_spriteBatch);
            bat.state.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void quit()
        {
            Exit();
        }
    }
}
