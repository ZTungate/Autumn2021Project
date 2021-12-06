using Microsoft.Xna.Framework;
using Poggus.Projectiles;
using Poggus;
using System;
using System.Collections.Generic;
using Poggus.Enemies.BoomerangThrowerStates;
using System.Text;

namespace Poggus.Enemies
{
    public class Thrower : AbstractEnemy
    {
        ProjectileFactory projectiles;
        int wait = 0;
        int throwDelay = EnemyConstants.throwerAttackDelay;
        const int RANDMOVE = 20;
        public Thrower(Point pos) : base(EnemyType.Thrower, pos, EnemyConstants.stdEnemySize.Size)
        {
            //Default a new thrower as a left thrower
            State = new ThrowerState(new Point(0, 1), Sprite, this);
            //Assign an arbitrary starting positon for the thrower
            //Pass the projectile handler in
            projectiles = ProjectileFactory.Instance;
            Health = EnemyConstants.throwerHealth;
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;
            if (StunTimer <= 0)
            {
                int lastFrame = Sprite.CurrentFrame;

                base.Update(gameTime);

                //Try to move the thrower
                TryRandomMove(lastFrame);

                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }

                wait -= gameTime.ElapsedGameTime.Milliseconds;
                if (throwDelay <= 0)
                {
                    //Attack and reset the delays
                    Attack();
                    wait = ProjectileConstants.boomerangLife; 
                    throwDelay = EnemyConstants.throwerAttackDelay;
                }
                else
                {
                    throwDelay -= gameTime.ElapsedGameTime.Milliseconds;
                }
                ColliderRect = new Rectangle(DestRect.Location + new Point(4, (int)(DestRect.Height / 2f) - 4), new Point(DestRect.Width - 4, (int)(DestRect.Height / 2f)));

            }
            else
            {
                //If stunned, decrement stun timer
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        private void TryRandomMove(int lastFrame)
        {
            //Move only if not waiting and the sprite frame changed.
            if (wait <= 0 && lastFrame != Sprite.CurrentFrame)
            {
                //Get a random number from 0 to 19
                Random rand = new Random();
                int value = rand.Next(RANDMOVE);

                //Change directions or move based on the random number
                if (value == 0)
                {
                    State.TurnUp();
                }
                else if (value == 1)
                {
                    State.TurnDown();
                }
                else if (value == 2)
                {
                    State.TurnRight();
                }
                else if (value == 3)
                {
                    State.TurnLeft();
                }
                else
                {
                    State.MoveForward();
                }
            }
        }
        private void Attack()
        {
            //Create a new boomerang moving the direction given at standard boomerang speed.
            projectiles.NewBoomerang(DestRect.Location, State.AttackDirection() * ProjectileConstants.RegBoomerangVelocity);
        }


    }
}
