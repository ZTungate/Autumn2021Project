using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint2;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
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

                //special after effects for some projectiles
                if (projectile is SwordBeamProjectile) {
                    // TODO: sword and arrow poofs
                }
                else if (projectile is BlueArrowProjectile | projectile is RegArrowProjectile) {

                }

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

        public ISprite CreateArrowPoofSprite()
        {
            return new ArrowPoofSprite(linkSpriteSheet);
        }

        public ISprite CreateRightSwordSprite()
        {
            return new RightSwordSprite(linkSpriteSheet);
        }

        public ISprite CreateLeftSwordSprite()
        {
            return new LeftSwordSprite(linkSpriteSheet);
        }

        public ISprite CreateUpSwordSprite()
        {
            return new UpSwordSprite(linkSpriteSheet);
        }

        public ISprite CreateDownSwordSprite()
        {
            return new DownSwordSprite(linkSpriteSheet);
        }

        public ISprite CreateFireSprite()
        {
            return new FireSprite(linkSpriteSheet);
        }

        public void NewRegArrow(Vector2 position,direction facing)
        {
            //Generate an arrow with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case direction.right:
                    regArrow = new RegArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightRegArrowSprite();
                    break;
                case direction.left:
                    regArrow = new RegArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(-1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftRegArrowSprite();
                    break;
                case direction.up:
                    regArrow = new RegArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, -1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpRegArrowSprite();
                    break;
                case direction.down:
                    regArrow = new RegArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, 1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownRegArrowSprite();
                    break;
            }
        }

        public void NewBlueArrow(Vector2 position, direction facing)
        {
            //Generate an arrow with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case direction.right:
                    regArrow = new BlueArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightBlueArrowSprite();
                    break;
                case direction.left:
                    regArrow = new BlueArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(-1, 0));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftBlueArrowSprite();
                    break;
                case direction.up:
                    regArrow = new BlueArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, -1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpBlueArrowSprite();
                    break;
                case direction.down:
                    regArrow = new BlueArrowProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, 1));
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownBlueArrowSprite();
                    break;

            }
        }

        public void NewSwordBeam(Vector2 position, direction facing)
        {
            //Generate a sword beam with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile swordBeam;
            switch (facing) {
                case direction.right:
                    swordBeam = new SwordBeamProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(1, 0));
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateRightSwordSprite();
                    break;
                case direction.left:
                    swordBeam = new SwordBeamProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(-1, 0));
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateLeftSwordSprite();
                    break;
                case direction.up:
                    swordBeam = new SwordBeamProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, -1));
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateUpSwordSprite();
                    break;
                case direction.down:
                    swordBeam = new SwordBeamProjectile(position, ProjectileConstants.ArrowVelocity * new Vector2(0, 1));
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateDownSwordSprite();
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

        public void NewBomb(Vector2 position, direction facing)
        {
            ISprite mySprite = CreateBombSprite();
            Vector2 bombPos = new Vector2();
            switch (facing) {
                case direction.down: //center and place the bomb below link
                    bombPos = new Vector2(position.X + (LinkConstants.linkSize - mySprite.SourceRect[mySprite.CurrentFrame].Width)/2 * LinkConstants.scaleX, position.Y + LinkConstants.linkSize * LinkConstants.scaleY);
                    break;
                case direction.up:
                    bombPos = new Vector2(position.X + (LinkConstants.linkSize - mySprite.SourceRect[mySprite.CurrentFrame].Width) / 2 * LinkConstants.scaleX, position.Y - mySprite.SourceRect[mySprite.CurrentFrame].Height * LinkConstants.scaleY);
                    break;
                case direction.right:
                    bombPos = new Vector2(position.X + LinkConstants.linkSize * LinkConstants.scaleX, position.Y + (LinkConstants.linkSize - mySprite.SourceRect[mySprite.CurrentFrame].Height) / 2 * LinkConstants.scaleY);
                    break;
                case direction.left:
                    bombPos = new Vector2(position.X - mySprite.SourceRect[mySprite.CurrentFrame].Width * LinkConstants.scaleX, position.Y + (LinkConstants.linkSize - mySprite.SourceRect[mySprite.CurrentFrame].Height) / 2 * LinkConstants.scaleY);
                    break;
            }
            IProjectile bomb = new BombProjectile(bombPos);
            projectiles.Add(bomb);
            bomb.Sprite = mySprite;
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

        public void LinkBoomerang(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new LinkBoomerangProjectile(position, velocity);
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

        public void LinkBlueBoomerang(Vector2 position, Vector2 velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new LinkBoomerangProjectile(position, velocity);
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

        public List<IProjectile> getProjs()
        {
            return projectiles;
        }

    }
}
