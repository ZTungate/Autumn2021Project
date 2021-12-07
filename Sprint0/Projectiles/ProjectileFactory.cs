using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Projectiles;
using Poggus;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Sound;
using Microsoft.Xna.Framework.Audio;

namespace Poggus.Projectiles
{
    public class ProjectileFactory
    {
        private List<IProjectile> projectiles;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private SoundManager soundManager { get; set; }

        private static ProjectileFactory instance = new ProjectileFactory();

        private Dictionary<IProjectile, SoundEffectInstance> boomerangSounds = new Dictionary<IProjectile, SoundEffectInstance>();
        private Dictionary<IProjectile, SoundEffectInstance> bombSounds = new Dictionary<IProjectile, SoundEffectInstance>();

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

        public void Initalize(SoundManager soundManager)
        {
            //Initialize the projectile list
            projectiles = new List<IProjectile>();
            this.soundManager = soundManager;
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
                if (projectile is SwordBeamProjectile)
                {
                    NewSwordBeamExplosions(projectile.GetPosition());
                }
                else if (projectile is BlueArrowProjectile | projectile is RegArrowProjectile)
                {
                    NewArrowPoof(projectile.GetPosition());
                }
                else if (projectile is BombProjectile)
                {
                    bombSounds[projectile].Stop();
                    //Spawn a large explosion.
                    NewBombExplosions(projectile.GetPosition());
                }
                else if (projectile is LinkBoomerangProjectile){
                    boomerangSounds[projectile].Stop();
                }
            }
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            //Draw each projectile on the projectile list
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
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
        public ISprite CreateArrowPoofSprite()
        {
            return new ArrowPoofSprite(linkSpriteSheet);
        }
        private ISprite CreateUpLeftSwordExplosionSprite()
        {
            return new UpLeftSwordExplosionSprite(linkSpriteSheet);
        }
        private ISprite CreateUpRightSwordExplosionSprite()
        {
            return new UpRightSwordExplosionSprite(linkSpriteSheet);
        }
        private ISprite CreateDownRightSwordExplosionSprite()
        {
            return new DownRightSwordExplosionSprite(linkSpriteSheet);
        }
        private ISprite CreateDownLeftSwordExplosionSprite()
        {
            return new DownLeftSwordExplosionSprite(linkSpriteSheet);
        }
        public ISprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(enemySpriteSheet);
        }
        public ISprite CreateBlueBoomerangSprite()
        {
            return new BlueBoomerangSprite(linkSpriteSheet);
        }
        public ISprite createBombExplosionSprite()
        {
            return new BombExplosionSprite(linkSpriteSheet);
        }

        //Spawners for projectiles/projectile groups
        public void NewRegArrow(Point position, Direction facing)
        {
            //Generate an arrow with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case Direction.right:
                    regArrow = new RegArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(1, 0)), ProjectileConstants.HorizArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightRegArrowSprite();
                    break;
                case Direction.left:
                    regArrow = new RegArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(-1, 0)), ProjectileConstants.HorizArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftRegArrowSprite();
                    break;
                case Direction.up:
                    regArrow = new RegArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, -1)), ProjectileConstants.VertArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpRegArrowSprite();
                    break;
                case Direction.down:
                    regArrow = new RegArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, 1)), ProjectileConstants.VertArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownRegArrowSprite();
                    break;
            }
        }

        public void NewBlueArrow(Point position, Direction facing)
        {
            //Generate an arrow with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile regArrow;
            switch (facing) {
                case Direction.right:
                    regArrow = new BlueArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(1, 0)), ProjectileConstants.HorizArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateRightBlueArrowSprite();
                    break;
                case Direction.left:
                    regArrow = new BlueArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(-1, 0)), ProjectileConstants.HorizArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateLeftBlueArrowSprite();
                    break;
                case Direction.up:
                    regArrow = new BlueArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, -1)), ProjectileConstants.VertArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateUpBlueArrowSprite();
                    break;
                case Direction.down:
                    regArrow = new BlueArrowProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, 1)), ProjectileConstants.VertArrowSize);
                    projectiles.Add(regArrow);
                    regArrow.Sprite = CreateDownBlueArrowSprite();
                    break;

            }
        }
        public void NewArrowPoof(Point position)
        {
            IProjectile arrowPoof = new ArrowPoofProjectile(position);
            projectiles.Add(arrowPoof);
            arrowPoof.Sprite = CreateArrowPoofSprite();
        }
        public IProjectile NewEnemyPoof(Point position, Point size)
        {
            IProjectile enemyPoof = new EnemyPoofProjectile(position, size);
            projectiles.Add(enemyPoof);
            enemyPoof.Sprite = createBombExplosionSprite();
            return enemyPoof;
        }
        public void NewSwordBeam(Point position, Direction facing)
        {
            //Generate a sword beam with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile swordBeam;
            switch (facing) {
                case Direction.right:
                    swordBeam = new SwordBeamProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(1, 0)), ProjectileConstants.horizSwordBeamSize, this);
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateRightSwordSprite();
                    break;
                case Direction.left:
                    swordBeam = new SwordBeamProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(-1, 0)), ProjectileConstants.horizSwordBeamSize, this);
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateLeftSwordSprite();
                    break;
                case Direction.up:
                    swordBeam = new SwordBeamProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, -1)), ProjectileConstants.vertSwordBeamSize, this);
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateUpSwordSprite();
                    break;
                case Direction.down:
                    swordBeam = new SwordBeamProjectile(position, (ProjectileConstants.ArrowVelocity * new Point(0, 1)), ProjectileConstants.vertSwordBeamSize, this);
                    projectiles.Add(swordBeam);
                    swordBeam.Sprite = CreateDownSwordSprite();
                    break;
            }
        }

        public void NewSwordBeamExplosions(Point pos)
        {
            //Create four new sword beam explosion projectiles at the given position with standard velocities
            IProjectile upLeft = new SwordBeamExplosionProjectile(pos, ProjectileConstants.upLeftSBExplosionVelocity);
            IProjectile upRight = new SwordBeamExplosionProjectile(pos, ProjectileConstants.upRightSBExplosionVelocity);
            IProjectile downRight = new SwordBeamExplosionProjectile(pos, ProjectileConstants.downRightSBExplosionVelocity);
            IProjectile downLeft = new SwordBeamExplosionProjectile(pos, ProjectileConstants.downLeftSBExplosionVelocity);

            //Assign sprites to the four projectiles
            upLeft.Sprite = CreateUpLeftSwordExplosionSprite();
            upRight.Sprite = CreateUpRightSwordExplosionSprite();
            downRight.Sprite = CreateDownRightSwordExplosionSprite();
            downLeft.Sprite = CreateDownLeftSwordExplosionSprite();

            //Add the projectiles to the list
            projectiles.Add(upLeft);
            projectiles.Add(upRight);
            projectiles.Add(downRight);
            projectiles.Add(downLeft);

        }

        public void NewFireball(Point position, Point velocity)
        {
            //Generate a fireball with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile fireball = new FireballProjectile(position, velocity);
            projectiles.Add(fireball);
            fireball.Sprite = CreateFireballSprite();
            soundManager.sound.playFireballSound();
        }

        public void NewBomb(Point position)
        {
            //Generate a bomb with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile bomb = new BombProjectile(position);
            projectiles.Add(bomb);
            bomb.Sprite = CreateBombSprite();
            bombSounds.Add(bomb, soundManager.sound.playBombDrop());
        }
        public void NewBombExplosions(Point pos)
        {
            //Generate 7 bomb explosions in a hexagon around the given position.
            Point stdSize = ProjectileConstants.bombExplosionSize;
            IProjectile center = new BombExplosionProjectile(pos);
            IProjectile topLeft = new BombExplosionProjectile(new Point(pos.X - (stdSize.X / 2), pos.Y - (int)(stdSize.Y * 0.866)));
            IProjectile topRight = new BombExplosionProjectile(new Point(pos.X + (stdSize.X / 2), pos.Y - (int)(stdSize.Y * 0.866)));
            IProjectile right = new BombExplosionProjectile(new Point(pos.X + stdSize.X ,pos.Y));
            IProjectile botRight = new BombExplosionProjectile(new Point(pos.X + (stdSize.X / 2), pos.Y + (int)(stdSize.Y * 0.866)));
            IProjectile botLeft = new BombExplosionProjectile(new Point(pos.X - (stdSize.X / 2), pos.Y + (int)(stdSize.Y * 0.866)));
            IProjectile left = new BombExplosionProjectile(new Point(pos.X - stdSize.X, pos.Y));
            List<IProjectile> list = new List<IProjectile>{ center, topLeft, topRight, right, botRight, botLeft, left };

            //Play bomb explosion sound
            soundManager.sound.playBombBlow();

            //Give each projectile a sprite and add it to the list of projectiles
            foreach(IProjectile projectile in list)
            {
                projectile.Sprite = createBombExplosionSprite();
                projectiles.Add(projectile);
            }

        }
        public void NewBoomerang(Point position, Point velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new BoomerangProjectile(position, velocity);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBoomerangSprite();

        }

        public void LinkBoomerang(Point position, Point velocity, ILink link)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new LinkBoomerangProjectile(position, velocity, link);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBoomerangSprite();
            boomerangSounds.Add(boomerang, soundManager.sound.playBoomerang());

        }

        public void NewBlueBoomerang(Point position, Point velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new BoomerangProjectile(position, velocity);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBlueBoomerangSprite();

        }

        public void LinkBlueBoomerang(Point position, Point velocity, ILink link)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile boomerang = new LinkBoomerangProjectile(position, velocity, link);
            projectiles.Add(boomerang);
            boomerang.Sprite = CreateBlueBoomerangSprite();
            boomerangSounds.Add(boomerang, soundManager.sound.playBoomerang());
        }

        public void NewFire(Point position, Point velocity)
        {
            //Generate a Boomerang with given position and velocity, add it to the list, and assign it a sprite.
            IProjectile fire = new FireProjectile(position, velocity);
            projectiles.Add(fire);
            fire.Sprite = CreateFireSprite();
        }
        public void NewStab(Point position, Direction dir)
        {
            IProjectile stab;
            switch (dir)
            {
                case Direction.up:
                    stab = new SwordStabProjectile(position,ProjectileConstants.vertSwordBeamSize);
                    projectiles.Add(stab);
                    break;
                case Direction.down:
                    stab = new SwordStabProjectile(position, ProjectileConstants.vertSwordBeamSize);
                    projectiles.Add(stab);
                    break;
                case Direction.left:
                    stab = new SwordStabProjectile(position, ProjectileConstants.horizSwordBeamSize);
                    projectiles.Add(stab);
                    break;
                case Direction.right:
                    stab = new SwordStabProjectile(position, ProjectileConstants.horizSwordBeamSize);
                    projectiles.Add(stab);
                    break;
            }
        }
        public List<IProjectile> getProjs()
        {
            return projectiles;
        }

        public void ClearProjectiles()
        {
            foreach (IProjectile projectile in projectiles) {
                if (projectile is LinkBoomerangProjectile){
                    boomerangSounds[projectile].Stop();
                }
            }
            projectiles.Clear();
        }

    }
}
