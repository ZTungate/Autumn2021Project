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

        private int interval = 120;
        private int timer = 0;
        private int attackTimer = 0;
        private int attackInterval = 4000;
        public Dragon(Point pos) : base(EnemyType.Dragon, pos, new Point(32, 32))
        {
            projectiles = ProjectileFactory.Instance;
            health = EnemyConstants.dragonHealth;
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;

            //Update the sprite
            Sprite.Update(gameTime);
            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                timer = 0;
                DestRect = new Rectangle(DragonMove(), DestRect.Size);
            }

            if(attackTimer < attackInterval)
            {
                attackTimer += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                attackTimer = 0;
                Attack();
            }
        }

        public Point DragonMove()
        {
            //Initialize an RNG to randomly move the dragon.
            Random rand = new Random();
            Point newPosition = DestRect.Location;
            int val = rand.Next(3);

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
            projectiles.NewFireBall(DestRect.Location, new Point(-3, -2)); //This one moves up and left.
            projectiles.NewFireBall(DestRect.Location, new Point(-3, 0)); //This one moves straight left.
            projectiles.NewFireBall(DestRect.Location, new Point(-3, 2)); //This one moves down and left.
        }
    }
}
