using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Projectiles
{
    public class ProjectileFactory
    {
        private List<IProjectile> projectiles;
        private Texture2D enemySpriteSheet;


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
        public void NewFireBall(Vector2 position, Vector2 velocity)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile fireball = new FireballProjectile(position, velocity);
            projectiles.Add(fireball);
            fireball.Sprite = CreateFireballSprite();
        }

        public ISprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(enemySpriteSheet);
        }

        public void NewBoomerang(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new BoomerangProjectile(position, velocity);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBoomerangSprite();
        }
        

    }
}
