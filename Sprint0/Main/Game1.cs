﻿using Microsoft.Xna.Framework;
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

namespace Poggus
{
    public class Game1 : Game
    {
        public static float gameScaleX, gameScaleY;
        public static Game1 instance;
        private Dungeon dungeon;
        
        private Texture2D fadeImage;
        private bool fade = false;
        private SpriteFont font;
        private Rectangle screenDims;
        float fadeTimer = 0.0f;
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
        private bool isPaused = false;
        private bool inventoryOpen = false;

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
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704;
            _graphics.ApplyChanges();
            screenDims = new Rectangle(new Point(0, 0), new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));
            //Initialize the sprite factories
            linkSpriteFactory = LinkSpriteFactory.Instance;
            enemySpriteFactory = EnemySpriteFactory.Instance;
            itemSpriteFactory = ItemSpriteFactory.Instance;
            blockSpriteFactory = BlockSpriteFactory.Instance;
            projectileFactory = ProjectileFactory.Instance;
            projectileFactory.Initalize();

            //Initialize sound
            soundManager = new SoundManager();

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

            //Create sprite for Link
            link.Sprite = linkSpriteFactory.RightIdleLinkSprite(link);

            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();

            //Load sounds
            soundManager.LoadContent(Content);

            handler = new CollisionHandler(this);
            
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (IController controller in controllerList) {
                controller.Update();
            }
            if (!isPaused)
            {
                //Update Link
                link.Update(gameTime);

                dungeon.UpdateCurrent(gameTime);

                //Update the projectiles
                projectileFactory.UpdateProjectiles(gameTime);

                //collision handler
                handler.Update();

                soundManager.ResumeMusic();

                base.Update(gameTime);
            }
            else {
                soundManager.StopMusic();
            }
        }
                    if (fade)
            {
                fadeTimer += 0.01f;
            }
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

            if (fade)
            {
                _spriteBatch.Draw(fadeImage, new Vector2(screenDims.X, screenDims.Y) ,null, Color.Black * fadeTimer, 0, new Vector2(screenDims.X, screenDims.Y), 10000, SpriteEffects.None, 1.0f);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        

        public void Reset()
        {
            
            link = new Link
            {
                ProjectileFactory = projectileFactory
            };
            link.Sprite = linkSpriteFactory.RightIdleLinkSprite(link);
            DoorFactory.instance.LoadContent(Content);
            LevelLoader.instance.ResetLevels();
            DungeonLoader.instance.ResetDungeon();
            LevelLoader.instance.LoadAllLevels(Content);
            DungeonLoader.instance.LoadDungeons();


            handler = new CollisionHandler(this);
            
        }

        public void fadeout()
        {
            fade = true;
            isPaused = true;
            //fadeImage.Width = _graphics.PreferredBackBufferWidth;
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
