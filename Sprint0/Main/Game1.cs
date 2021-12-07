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
using Microsoft.Xna.Framework.Audio;
using Poggus.Sound;
using Poggus.Main;
using Poggus.UI;
using Poggus.Levels.Generation;
using Poggus.PauseMenu;

namespace Poggus
{
    public class Game1 : Game
    {
        const int textScale = 3;
        const int BUFFERWIDTH = 1024;
        const int BUFFERHEIGHT = 704;
        const int blackoutScale = 10000;
        public static float gameScaleX, gameScaleY;
        public static float heightScalar = 0.75f;
        public static Game1 instance;
        private Dungeon dungeon;
        
        private Texture2D fadeImage;
        private SpriteFont font;
        private Rectangle screenDims;
        private bool win = false;
        private bool lose = false;
        private StateChanges stateChange;
        public List<IController> controllerList;

        public CollisionDetection detector = new CollisionDetection();
        public ICollision collision;
        public CollisionHandler handler;
        public HUDHandler hudHandler;
        public PauseMenuHandler menuHandler;
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        
        //Sprite factories
        public LinkSpriteFactory linkSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        public ItemSpriteFactory itemSpriteFactory;
        public BlockSpriteFactory blockSpriteFactory;
        public HUDSpriteFactory hudSpriteFactory;
        public PauseSpriteFactory pauseSpriteFactory;
        //Link
        public ILink link;

        //Projectiles
        public ProjectileFactory projectileFactory;
        private bool isPaused = false;
        public bool inventoryOpen = false; //public for pause menu

        //Sound
        public SoundManager soundManager;

        public Game1()
        {
            instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = BUFFERWIDTH;
            _graphics.PreferredBackBufferHeight = BUFFERHEIGHT;
            _graphics.ApplyChanges();
            screenDims = new Rectangle(new Point(), new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));
            //Initialize the sprite factories
            linkSpriteFactory = LinkSpriteFactory.Instance;
            enemySpriteFactory = EnemySpriteFactory.Instance;
            itemSpriteFactory = ItemSpriteFactory.Instance;
            blockSpriteFactory = BlockSpriteFactory.Instance;
            projectileFactory = ProjectileFactory.Instance;
            hudSpriteFactory = HUDSpriteFactory.instance;
            pauseSpriteFactory = PauseSpriteFactory.instance;

            //Initialize sound
            soundManager = SoundManager.Instance;

            projectileFactory.Initalize(soundManager);

            

            //Initialize Player (Link)
            link = new Link
            {
                ProjectileFactory = projectileFactory,
                SoundManager = soundManager
            };
            controllerList = new List<IController>()
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Credits");
            fadeImage = Content.Load<Texture2D>("fadePixel");
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

            hudSpriteFactory.LoadContent(Content);
            pauseSpriteFactory.LoadContent(Content);
            //Create sprite for Link
            link.Sprite = linkSpriteFactory.RightIdleLinkSprite(link);

            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();
            dungeon.GetCurrentLevel().DoEnemySpawnAnimation();

            hudHandler = new HUDHandler(this.link);
            menuHandler = new PauseMenuHandler(this, font);
            //Load sounds
            soundManager.LoadContent(Content);

            handler = new CollisionHandler(this)
            {
                SoundManager = soundManager
            };
            stateChange = new StateChanges(this, font, fadeImage, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }
            
            if (!isPaused) {
                
                Camera.main.Update(gameTime);

                //Update Link
                link.Update(gameTime);
                if(link.Health <= 0)
                {
                    toggleLose();
                }
                dungeon.UpdateCurrent(gameTime);

                //Update the projectiles
                projectileFactory.UpdateProjectiles(gameTime);

                //collision handler
                handler.Update();
                hudHandler.Update(gameTime);

                soundManager.ResumeMusic();

                base.Update(gameTime);
            }
            else {
                if (!inventoryOpen)
                {
                    menuHandler.Update(); //only if inventory isn't open
                }
                soundManager.StopMusic();
            }
            if (win)
            {
                stateChange.winGame();
            } else if (lose)
            {
                stateChange.loseGame();
            }
            
                stateChange.Update();
            
        }

    protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            //Using front to back sorting, and point clamp to improve look of pixel art sprites
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            dungeon.Draw(_spriteBatch);

            //Draw all projectiles
            projectileFactory.DrawProjectiles(_spriteBatch);

            //Draw Link
            link.Draw(_spriteBatch);

            foreach (KeyValuePair<Point, Level> entry in dungeon.GetLevelDictionary())
            {
                entry.Value.DrawDoorOverlay(_spriteBatch);
            }

            hudHandler.Draw(_spriteBatch);
            menuHandler.Draw(_spriteBatch, fadeImage);
            stateChange.fadeOut();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset()
        {
            link.Reset();

            link.Sprite = linkSpriteFactory.RightIdleLinkSprite(link);
            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.ResetLevels();
            DungeonLoader.instance.ResetDungeon();
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();

            ProjectileFactory.Instance.ClearProjectiles();
            soundManager.LoadContent(Content);
            stateChange.Reset();
            win = false;
            lose = false;
            hudHandler.Reset();
            Camera.main.Reset();
            menuHandler.Reset();
            toggleSound();
            if(soundManager.volume < 1)
            {
                toggleSound();
            }

            handler = new CollisionHandler(this)
            {
                SoundManager = soundManager
            };

            dungeon.GetCurrentLevel().DoEnemySpawnAnimation();
        }
        //DO NOT MODIFY THIS FUNCTION (IT IS NOT THE RESET FUNCTION!)
        public void TempGenerateNewDungeon()
        {
            link.Reset();

            link.Sprite = linkSpriteFactory.RightIdleLinkSprite(link);
            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.ResetLevels();
            DungeonLoader.instance.ResetDungeon();
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();
            DungeonGenerator dungeonGenerator = new DungeonGenerator();

            dungeon = dungeonGenerator.GenerateDungeon();

            ProjectileFactory.Instance.ClearProjectiles();
            soundManager.LoadContent(Content);
            stateChange.Reset();
            win = false;
            lose = false;
            hudHandler.Reset();
            Camera.main.Reset();

            if (soundManager.volume < 1)
            {
                toggleSound();
            }

            handler = new CollisionHandler(this)
            {
                SoundManager = soundManager
            };
            dungeon.GetCurrentLevel().DoEnemySpawnAnimation();
        }
        public void toggleWin()
        {
            
            win = !win;
            
        }

        public void toggleLose()
        {
            
            lose = !lose;
        }
        
        public void SetDungeon(Dungeon dungeon)
        {
            this.dungeon = dungeon;
            
        }
        public Dungeon GetDungeon()
        {
            return this.dungeon;
        }
        public bool Paused()
        {
            return isPaused;
        }
        public void togglePause()
        {
            isPaused = !isPaused;
            link.State.Idle();
            if (!isPaused)
            {
                menuHandler.options = false;
            }
        }

        public void toggleSound()
        {
            soundManager.ToggleSound();
            
        }
        public void toggleOpenInventory()
        {
            inventoryOpen = !inventoryOpen;
            isPaused = inventoryOpen;
        }
        public void Quit()
        {
            Exit();
        }
    }
}
