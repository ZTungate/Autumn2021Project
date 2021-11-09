using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies.Sprites;
using Poggus.Player;
using Poggus.Items.ItemSprites;
using Poggus.Blocks.Sprites;
using System.Collections.Generic;
using Poggus.Projectiles;
using Poggus.Collisions;
using Poggus.Levels;
using Poggus.Levels.Sprites;

namespace Poggus
{
    public class Game1 : Game
    {
        public static Game1 instance;
        private Dungeon dungeon;
        public ISprite sprite;

        private SpriteFont font;

        public List<IController> controllerList;

        public CollisionDetection detector = new CollisionDetection();
        public ICollision collision;
        public CollisionHandler handler;

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        //Sprite factories
        public LinkSpriteFactory linkSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        public ItemSpriteFactory itemSpriteFactory;
        public BlockSpriteFactory blockSpriteFactory;

        //Link
        public ILink link;

        //Projectiles
        public ProjectileFactory projectileFactory;

        public Game1()
        {
            instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704;
            _graphics.ApplyChanges();

            //Initialize the sprite factories
            linkSpriteFactory = LinkSpriteFactory.Instance;
            enemySpriteFactory = EnemySpriteFactory.Instance;
            itemSpriteFactory = ItemSpriteFactory.Instance;
            blockSpriteFactory = BlockSpriteFactory.Instance;
            projectileFactory = ProjectileFactory.Instance;
            projectileFactory.Initalize();

            controllerList = new List<IController>()
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            //Initialize Player (Link)
            link = new Link
            {
                ProjectileFactory = projectileFactory
            };
            handler = new CollisionHandler(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Credits");

            //Load all textures from the link sprite factory.
            linkSpriteFactory.LoadAllTextures(Content);

            //Load all textures from the enemy sprite factory.
            enemySpriteFactory.LoadAllTextures(Content);
            //Load all textures for the projectile factory.
            projectileFactory.LoadAllTextures(Content);

            //Load all block textures
            blockSpriteFactory.LoadAllTextures(Content);

            //Load all item textures and generate items (must be done after textures are loaded)
            itemSpriteFactory.LoadAllTextures(Content);

            //Create sprite for Link
            link.sprite = linkSpriteFactory.RightIdleLinkSprite(link);

            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();

            handler = new CollisionHandler(this);

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }
            
            //Update Link
            link.Update(gameTime);

            dungeon.UpdateCurrent(gameTime);

            //Update the projectiles
            projectileFactory.UpdateProjectiles(gameTime);

            //TODO: poop
            handler.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            //Using front to back sorting, and point clamp to improve look of pixel art sprites
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            dungeon.DrawCurrent(_spriteBatch);

            //Draw all projectiles
            projectileFactory.DrawProjectiles(_spriteBatch);

            //Draw Link
            link.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset()
        {
            link = new Link();
            link.sprite = LinkSpriteFactory.Instance.RightIdleLinkSprite(link);


            //Set the enemy sprite factory to a new instance
            enemySpriteFactory = EnemySpriteFactory.Instance;

            //Re-Initialize the projectile factory.
            projectileFactory.Initalize();
        }
        public void SetDungeon(Dungeon dungeon)
        {
            this.dungeon = dungeon;
        }
        public Dungeon GetDungeon()
        {
            return this.dungeon;
        }
        public void Quit()
        {
            Exit();
        }
    }
}
