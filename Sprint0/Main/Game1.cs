using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Enemies;
using Sprint2.Player;
using Sprint2.Items;
using Sprint2.Blocks;
using System.Collections.Generic;
using Sprint2.Projectiles;
using Sprint0.Collisions;
using Sprint0.Levels;

namespace Sprint2
{
    public class Game1 : Game
    {
        public ISprite sprite;

        private SpriteFont font;

        public List<IController> controllerList;

        public CollisionDetection detector = new CollisionDetection();
        public ICollision collision;

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        //Sprite factories
        public LinkSpriteFactory linkSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        public ItemSpriteFactory itemSpriteFactory;
        public BlockSpriteFactory blockSpriteFactory;

        //Link
        public ILink link;

        //Enemies
        public List<IEnemy> enemies;
        public int currentEnemy;

        //Items
        public List<IItem> items;
        public int currentItem;

        //Projectiles
        public ProjectileFactory projectileFactory;
        //Blocks
        public IBlock currentBlock;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
                new MouseController(this),
            };

            //Initialize Player (Link)
            link = new Link
            {
                ProjectileFactory = projectileFactory
            };

            //Temorary variable for item location
            Point itemPos = new Point(300, 100);
            items = new List<IItem>()
            {
                new ArrowItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new BombItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new BoomerangItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new BowItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new ClockItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new CompassItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new FairyItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new HeartContainerItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new HeartItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new KeyItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new RupeeItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0)),
                new TriforcePieceItem(new Rectangle(itemPos.X, itemPos.Y, 0, 0))
            };

            //Initialize enemies 
            enemies = new List<IEnemy>()
            {
                new Dragon(projectileFactory),
                new Skeleton(),
                new Bat(),
                new Slime(),
                new OldMan(),
                new Thrower(projectileFactory),
            };

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
            currentBlock = blockSpriteFactory.CurrentSprite();

            //Load all item textures and generate items (must be done after textures are loaded)
            itemSpriteFactory.LoadAllTextures(Content);

            foreach(IItem item in items)
            {
                item.CreateSprite();
            }

            //Create sprite for Link
            link.sprite = linkSpriteFactory.RightIdleLinkSprite(link);

            //Create sprites for all enemies.
            foreach(IEnemy enemy in enemies){
                enemy.Sprite = enemySpriteFactory.MakeSprite(enemy);
            }


            LevelLoader.instance.LoadAllLevels();
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }
            
            //Update Link
            link.Update(gameTime);

            //Update the current enemy
            enemies[currentEnemy].Update(gameTime);

            //Update the projectiles
            projectileFactory.UpdateProjectiles(gameTime);

            items[currentItem].Update(gameTime);

            currentBlock.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            //Using front to back sorting, and point clamp to improve look of pixel art sprites
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);
   
            //Draw Link
            link.Draw(_spriteBatch);

            //Draw the current enemy
            enemies[currentEnemy].Sprite.Draw(_spriteBatch);

            //Draw all projectiles
            projectileFactory.DrawProjectiles(_spriteBatch);

            items[currentItem].Draw(_spriteBatch);

            currentBlock.Draw(_spriteBatch);

            //temporary
            LevelLoader.instance.DrawLevels(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset()
        {
            link = new Link();
            link.sprite = LinkSpriteFactory.Instance.RightIdleLinkSprite(link);
            blockSpriteFactory.Reset();
            currentBlock = blockSpriteFactory.CurrentSprite();

            //Reset item
            currentItem = 0;

            //Set the enemy sprite factory to a new instance
            enemySpriteFactory = EnemySpriteFactory.Instance;

            //Reset currentEnemy
            currentEnemy = 0;

            //Reset the enemy list to all new instances of enemies.
            enemies = new List<IEnemy>()
            {
                new Dragon(projectileFactory),
                new Skeleton(),
                new Bat(),
                new Slime(),
                new OldMan(),
                new Thrower(projectileFactory),
            };
            //Create sprites for all enemies.
            foreach (IEnemy enemy in enemies)
            {
                enemy.Sprite = enemySpriteFactory.MakeSprite(enemy);
            }

            //Re-Initialize the projectile factory.
            projectileFactory.Initalize();
        }
        public void Quit()
        {
            Exit();
        }
    }
}
