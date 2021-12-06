using Microsoft.Xna.Framework;
using Poggus.Helpers;
using Poggus.Projectiles;
using Poggus;
using Poggus.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class Dragon : AbstractEnemy
    {
        //ProjectileHandler for spawning fireballs during an attack
        ProjectileFactory projectiles;
        const int RANDMOVE = 3;
        private int interval = 120;
        private int timer = 0;
        private int attackTimer = 0;
        private int attackInterval = EnemyConstants.dragonAttackInterval;
        public Dragon(Point pos) : base(EnemyType.Dragon, pos, EnemyConstants.dragonSize.Size)
        {
            projectiles = ProjectileFactory.Instance;
            Health = EnemyConstants.dragonHealth;
        }

        public override void Update(GameTime gameTime)
        {

            oldPosition = DestRect.Location;
            if (StunTimer <= 0)
            {
                //Update the sprite
                int lastFrame = Sprite.CurrentFrame;
                Sprite.Update(gameTime);

                if (lastFrame != Sprite.CurrentFrame)
                {
                    DestRect = new Rectangle(DragonMove(), DestRect.Size);
                }
                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }

                //Attack if enough time has passed since last attack.
                if (attackTimer < attackInterval)
                {
                    attackTimer += gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    attackTimer = 0;
                    Attack();
                }
                ColliderRect = new Rectangle(DestRect.Location + new Point(4, (int)(DestRect.Height / 2f) - 4), new Point(DestRect.Width - 4, (int)(DestRect.Height / 2f)));

            }
            else
            {
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        public Point DragonMove()
        {
            //Initialize an RNG to randomly move the dragon.
            Random rand = new Random();
            Point newPosition = DestRect.Location;
            int val = rand.Next(RANDMOVE);

            //1/3 chance to move forwards, 1/3 chance to move back, and 1/3 chance to do nothing.
            if (val == 0)
            {
                newPosition.X += EnemyConstants.dragonMoveSpeed;
            }
            else if (val == 1)
            {
                newPosition.X -= EnemyConstants.dragonMoveSpeed;
            }
                return newPosition;
        }

        public void Attack()
        {
            //Generate three fireballs starting at the dragon's location.
            projectiles.NewFireball(DestRect.Location, new Point(-3, -2)); //This one moves up and left.
            projectiles.NewFireball(DestRect.Location, new Point(-3, 0)); //This one moves straight left.
            projectiles.NewFireball(DestRect.Location, new Point(-3, 2)); //This one moves down and left.
        }
    }
}
