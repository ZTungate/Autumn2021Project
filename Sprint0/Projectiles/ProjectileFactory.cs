using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Projectiles
{
    public class ProjectileFactory
    {
        private List<IProjectile> projectiles;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;


        private static ProjectileFactory instance = new ProjectileFactory();

        public static ProjectileFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileFactory()
        {
        }

        public void Initalize()
        {
            //Initialize the projectile list
            projectiles = new List<IProjectile>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("EnemySpriteSheet");
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            //Prepare a list to hold dead projectiles.
            List<IProjectile> toRemove = new List<IProjectile>();

            //Update each projectile still on the list.
            foreach(IProjectile projectile in projectiles)
            {
                if(projectile.Life > 0)
                {
                    //Update the projectile if it still has life
                    projectile.Update(gameTime);
                }
                else
                {
                    //If life < 0, add it to the list for removal.
                    toRemove.Add(projectile);
                }
            }
            //Remove all projectiles that had life < 0 from the active list.
            foreach(IProjectile projectile in toRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            //Draw each projectile on the projectile list
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Sprite.Draw(spriteBatch);
            }
        }
        public ISprite CreateFireballSprite()
        {
            return new FireballSprite(enemySpriteSheet);
        }

        public ISprite CreateBombSprite()
        {
            return new BombSprite(linkSpriteSheet);
        }

        public ISprite CreateRightRegArrowSprite()
        {
            return new RightRegArrowSprite(linkSpriteSheet);
        }
        public ISprite CreateLeftRegArrowSprite()
        {
            return new LeftRegArrowSprite(linkSpriteSheet);
        }
        public ISprite CreateUpRegArrowSprite()
        {
            return new UpRegArrowSprite(linkSpriteSheet);
        }
        public ISprite CreateDownRegArrowSprite()
        {
            return new DownRegArrowSprite(linkSpriteSheet);
        }

        public ISprite CreateRightBlueArrowSprite()
        {
            return new RightBlueArrowSprite(linkSpriteSheet);
        }

        public ISprite CreateLeftBlueArrowSprite()
        {
            return new LeftBlueArrowSprite(linkSpriteSheet);
        }

        public ISprite CreateUpBlueArrowSprite()
        {
            return new UpBlueArrowSprite(linkSpriteSheet);
        }

        public ISprite CreateDownBlueArrowSprite()
        {
            return new DownBlueArrowSprite(linkSpriteSheet);
        }

        public ISprite CreateFireSprite()
        {
            return new FireSprite(linkSpriteSheet);
        }

        public void NewRegArrow(Vector2 position, Vector2 velocity, Player.direction facing)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case Player.direction.right:
                    regArrow = new RegArrowProjectile(position, 6 * new Vector2(1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightRegArrowSprite();
                    break;
                case Player.direction.left:
                    regArrow = new RegArrowProjectile(position, 6 * new Vector2(-1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftRegArrowSprite();
                    break;
                case Player.direction.up:
                    regArrow = new RegArrowProjectile(position, 6 * new Vector2(0, -1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpRegArrowSprite();
                    break;
                case Player.direction.down:
                    regArrow = new RegArrowProjectile(position, 6 * new Vector2(0, 1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownRegArrowSprite();
                    break;

            }
        }

        public void NewBlueArrow(Vector2 position, Vector2 velocity, Player.direction facing)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case Player.direction.right:
                    regArrow = new BlueArrowProjectile(position, 6 * new Vector2(1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightBlueArrowSprite();
                    break;
                case Player.direction.left:
                    regArrow = new BlueArrowProjectile(position, 6 * new Vector2(-1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftBlueArrowSprite();
                    break;
                case Player.direction.up:
                    regArrow = new BlueArrowProjectile(position, 6 * new Vector2(0, -1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpBlueArrowSprite();
                    break;
                case Player.direction.down:
                    regArrow = new BlueArrowProjectile(position, 6 * new Vector2(0, 1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownBlueArrowSprite();
                    break;

            }
        }

        public void NewFireBall(Vector2 position, Vector2 velocity)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile fireball = new FireballProjectile(position, velocity);
            projectiles.Add(fireball);
            fireball.Sprite = CreateFireballSprite();
        }

        public void NewBomb(Vector2 position)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile bomb = new BombProjectile(position);
            projectiles.Add(bomb);
            bomb.Sprite = CreateBombSprite();
        }

        public ISprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(enemySpriteSheet);
        }

        public ISprite CreateBlueBoomerangSprite()
        {
            return new BlueBoomerangSprite(linkSpriteSheet);
        }

        public void NewBoomerang(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new BoomerangProjectile(position, velocity);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBoomerangSprite();
        }

        public void NewBlueBoomerang(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new BoomerangProjectile(position, velocity);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBlueBoomerangSprite();
        }

        public void NewFire(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile fire = new FireProjectile(position, velocity);
            projectiles.Add(fire);
            fire.Sprite = CreateFireSprite();
        }

    }
}
